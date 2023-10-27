using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;
        private readonly ILogService _logService;
        private readonly IPacienteService _pacienteService;
        private readonly IUsuarioService _usuarioService;

        public ConsultaController(IConsultaService consultaService, ILogService logService, IPacienteService pacienteService, IUsuarioService usuarioService)
        {
            _consultaService = consultaService;
            _logService = logService;
            _pacienteService = pacienteService;
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpPost]
        public IActionResult Post([FromBody] ConsultaCreateDTO consultaCreate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                var verificaSeExsitePaciente = _pacienteService.GetById(consultaCreate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(consultaCreate.UsuarioId);
                if (verificaSeExisteUsuario == null || verificaSeExsitePaciente == null)
                {
                    return NoContent();
                }

                int id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                if (tipo == "Médico")
                {
                    consultaCreate.UsuarioId = id;
                }
                ConsultaGetDto consultaGet = _consultaService.CreateConsulta(consultaCreate);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {id}, cadastrou a consulta de id {consultaGet.Id}.",
                    Dominio = "Consulta-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Consulta salvo com sucesso.", consultaGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpGet]
        public ActionResult<IEnumerable<ConsultaGetDto>> Get([FromQuery] int? pacienteId)
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
                    // Retorna consultas do paciente específico
                    var consultas = _consultaService.GetAllConsultas().Where(e => e.PacienteId == pacienteId.Value);

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou consultas do paciente de id {pacienteId}.",
                        Dominio = "Consulta-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(consultas);
                }
                else
                {
                    // Retorna todos as consultas
                    var consultas = _consultaService.GetAllConsultas();

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou todas as consultas.",
                        Dominio = "Consulta-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(consultas);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [HttpPut("{id}")]
        public ActionResult<ConsultaGetDto> Update([FromRoute] int id, [FromBody] ConsultaUpdateDTO consultaUpdate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                ConsultaGetDto verificaSeExiste = _consultaService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico")
                {
                    consultaUpdate.UsuarioId = _id;
                }

                var verificaSeExisteUsuario = _usuarioService.GetById(consultaUpdate.UsuarioId);
                var verificaSeExsitePaciente = _pacienteService.GetById(consultaUpdate.PacienteId);
                if (verificaSeExisteUsuario == null || verificaSeExsitePaciente == null)
                {
                    return NoContent();
                }

                ConsultaGetDto consultaGet = _consultaService.UpdateConsulta(consultaUpdate, id);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou a consulta de id {id}.",
                    Dominio = "Consulta-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(consultaGet);
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

                bool remocao = _consultaService.DeleteConsulta(id);
                if (remocao)
                {
                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, excluiu a consulta de id {id}.",
                        Dominio = "Consulta-excluir."
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
