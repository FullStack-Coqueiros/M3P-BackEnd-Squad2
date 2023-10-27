using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly ILogService _logService;
        private readonly IPacienteService _pacienteService;


        public EnderecoController(IEnderecoService enderecoService, ILogService logService, IPacienteService pacienteService)
        {
            _enderecoService = enderecoService;
            _logService = logService;
            _pacienteService = pacienteService;
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPost]
        public ActionResult<EnderecoGetDto> Post([FromBody] EnderecoCreateDto enderecoCreate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                var verificaSeExsitePaciente = _pacienteService.GetById(enderecoCreate.PacienteId);
                if (verificaSeExsitePaciente == null)
                {
                    return NoContent();
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                EnderecoGetDto enderecoGet = _enderecoService.CreateEndereco(enderecoCreate);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, cadastrou o endereço de id {enderecoGet.Id}.",
                    Dominio = "Endereço-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Endereco cadastrado com sucesso", enderecoGet);

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet]
        public ActionResult<IEnumerable<EnderecoGetDto>> Get([FromQuery] int? pacienteId)
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
                    var endereco = _enderecoService.GetByRelationship(pacienteId.Value);

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou endereço do paciente de id {pacienteId}.",
                        Dominio = "Endereço-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(endereco);
                }
                else
                {
                    var enderecos = _enderecoService.GetAllEnderecos();

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou todos os  endereços.",
                        Dominio = "Endereço-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(enderecos);
                }

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                var endereco = _enderecoService.GetById(id);
                if (endereco == null)
                {
                    return NoContent();
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, listou endereço de id {id}.",
                    Dominio = "Endereço-listar."
                };
                _logService.CreateLog(logModel);

                return Ok(endereco);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] EnderecoUpdateDto enderecoUpdate)  //terminar essa controller
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaExistencia = _enderecoService.GetById(id);
                if (verificaExistencia == null)
                {
                    return NoContent();
                }
                var verificaSeExsitePaciente = _pacienteService.GetById(enderecoUpdate.PacienteId);
                if (verificaSeExsitePaciente == null)
                {
                    return NoContent();
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                _enderecoService.UpdateEndereco(enderecoUpdate, id);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou o endereço de id {id}.",
                    Dominio = "Endereço-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(enderecoUpdate);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }

        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
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

                bool response = _enderecoService.DeleteEndereco(id);
                if (response == false)
                {
                    return NoContent();
                }

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, excluiu o endereço de id {id}.",
                    Dominio = "Endereço-excluir."
                };
                _logService.CreateLog(logModel);

                return Accepted();
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }

        }
    }
}
