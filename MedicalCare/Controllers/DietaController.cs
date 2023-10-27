using MedicalCare.DTO;
using MedicalCare.Enums;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;


namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaController : ControllerBase
    {
        private readonly IDietaService _dietaService;
        private readonly IPacienteService _pacienteService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogService _logService;

        public DietaController(IDietaService dietaService, IPacienteService pacienteService, IUsuarioService usuarioService, ILogService logService)
        {
            _dietaService = dietaService;
            _pacienteService = pacienteService;
            _usuarioService = usuarioService;
            _logService = logService;
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPost]
        public IActionResult Post([FromBody] DietaCreateDto dietaCreateDto)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(dietaCreateDto.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(dietaCreateDto.UsuarioId);
                if (verificaSeExsitePaciente == null || verificaSeExisteUsuario == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico" || tipo =="Enfermeiro")
                {
                    dietaCreateDto.UsuarioId = _id;
                }
                DietaGetDto dietaGet = _dietaService.CreateDieta(dietaCreateDto);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, cadastrou a dieta de id {dietaGet.Id}.",
                    Dominio = "Dieta-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Dieta salva com sucesso.", dietaGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet]
        public ActionResult<IEnumerable<DietaGetDto>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                int id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                if (pacienteId.HasValue)
                {
                    var dietas = _dietaService.GetDietasByPaciente(pacienteId.Value);

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou dietas do paciente de id {pacienteId}.",
                        Dominio = "Dieta-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(dietas);
                }
                else
                {
                    var dietas = _dietaService.GetAllDietas();

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou todas as dietas.",
                        Dominio = "Dieta-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(dietas);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public ActionResult<DietaGetDto> Update([FromRoute] int id, [FromBody] DietaUpdateDto dietaUpdateDto)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                DietaGetDto verificaSeExiste = _dietaService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico" || tipo =="Enfermeiro")
                {
                    dietaUpdateDto.UsuarioId = _id;
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(dietaUpdateDto.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(dietaUpdateDto.UsuarioId);
                if (verificaSeExisteUsuario == null || verificaSeExsitePaciente == null)
                {
                    return NoContent();
                }

                DietaGetDto dietaGet = _dietaService.UpdateDieta(dietaUpdateDto, id);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou a dieta de id {id}.",
                    Dominio = "Dieta-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(dietaGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                bool remocao = _dietaService.DeleteDieta(id);
                if (remocao)
                {
                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, excluiu a dieta de id {id}.",
                        Dominio = "Dieta-excluir."
                    };
                    _logService.CreateLog(logModel);
                    return Accepted();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }
    }
}
