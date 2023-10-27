using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;

        private readonly ILogService _logService;
        private readonly IPacienteService _pacienteService;
        private readonly IUsuarioService _usuarioService;

        public ExercicioController(IExercicioService exercicioService, ILogService logService, IPacienteService pacienteService, IUsuarioService usuarioService)
        {
            _exercicioService = exercicioService;
            _logService = logService;
            _pacienteService = pacienteService;
            _usuarioService = usuarioService;
        }


        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPost]
        public IActionResult Post([FromBody] ExercicioCreateDto exercicioCreate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(exercicioCreate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(exercicioCreate.UsuarioId);
                if (verificaSeExsitePaciente == null || verificaSeExisteUsuario == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico")
                {
                    exercicioCreate.UsuarioId = _id;
                }

                ExercicioGetDto exercicioGet = _exercicioService.CreateExercicio(exercicioCreate);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, cadastrou o exercício de id {exercicioGet.Id}.",
                    Dominio = "Exercicio-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Exercicio salvo com sucesso", exercicioGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }

        }


        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public ActionResult<ExercicioGetDto> Update([FromRoute] int id, [FromBody] ExercicioUpdateDto exercicioUpdate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(exercicioUpdate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(exercicioUpdate.UsuarioId);
                if (verificaSeExsitePaciente == null || verificaSeExisteUsuario == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico")
                {
                    exercicioUpdate.UsuarioId = _id;
                }


                ExercicioGetDto consultaNoSistema = _exercicioService.GetById(id);
                if(consultaNoSistema == null)
                {
                    return NoContent();
                    
                }

                ExercicioGetDto exercicioGet = _exercicioService.UpdateExercicio(exercicioUpdate, id);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou o exercício de id {exercicioGet.Id}.",
                    Dominio = "Exercicio-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(exercicioGet);
            }

            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }


        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet]
        public ActionResult<IEnumerable<ExercicioGetDto>> Get([FromQuery] int? pacienteId)
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
                    var exercicio = _exercicioService.GetAllExercicios().Where(e => e.PacienteId == pacienteId.Value);

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, listou exercicios do paciente com id {pacienteId}.",
                        Dominio = "Exercicio-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok (exercicio);
                }
                else
                {
                    var exercicios = _exercicioService.GetAllExercicios();

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, listou todos os exercícios.",
                        Dominio = "Exercicio-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(exercicios);
                }
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

                bool remocao = _exercicioService.DeleteExercicio(id);
                if (remocao)
                {
                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, excluiu o exercicio de id {id}.",
                        Dominio = "Exercicio-excluir."
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

        


