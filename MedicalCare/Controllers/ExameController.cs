using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;


namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IExameService _exameService;
        private readonly ILogService _logService;
        private readonly IPacienteService _pacienteService;
        private readonly IUsuarioService _usuarioService;

        public ExameController(IExameService exameService, ILogService logService, IPacienteService pacienteService, IUsuarioService usuarioService)
        {
            _exameService = exameService;
            _logService = logService;
            _pacienteService = pacienteService;
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpPost]
        public IActionResult Post([FromBody] ExameCreateDto exameCreate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(exameCreate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(exameCreate.UsuarioId);
                if (verificaSeExsitePaciente == null || verificaSeExisteUsuario == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico")
                {
                    exameCreate.UsuarioId = _id;
                }
                ExameGetDto exameGet = _exameService.CreateExame(exameCreate);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, cadastrou o exame de id {exameGet.Id}.",
                    Dominio = "Exame-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Exame salvo com sucesso.", exameGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpGet]
        public ActionResult<IEnumerable<ExameGetDto>> Get([FromQuery] int? pacienteId)
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

                if (pacienteId.HasValue)
                {
                    // Retorna exames do paciente específico
                    var exame = _exameService.GetAllExames().Where(e => e.PacienteId == pacienteId.Value);

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, listou exames do paciente com id {pacienteId}.",
                        Dominio = "Exame-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(exame);
                }
                else
                {
                    // Retorna todos os exames
                    var exames = _exameService.GetAllExames();

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, listou todos os exames.",
                        Dominio = "Exame-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(exames);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpPut("{id}")]
        public ActionResult<ExameGetDto> Update([FromRoute] int id, [FromBody] ExameUpdateDto exameUpdate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(exameUpdate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(exameUpdate.UsuarioId);
                if (verificaSeExsitePaciente == null || verificaSeExisteUsuario == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico")
                {
                    exameUpdate.UsuarioId = _id;
                }
                ExameGetDto verificaSeExiste = _exameService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NoContent();
                }

                ExameGetDto exameGet = _exameService.UpdateExame(exameUpdate, id);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou o exame de id {exameGet.Id}.",
                    Dominio = "Exame-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(exameGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
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

                bool remocao = _exameService.DeleteExame(id);
                if (remocao)
                {
                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, excluiu o exame de id {id}.",
                        Dominio = "Exame-excluir."
                    };
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
