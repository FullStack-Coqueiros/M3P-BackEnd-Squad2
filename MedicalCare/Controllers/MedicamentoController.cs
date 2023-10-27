using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalCare.DTO;

namespace MedicalCare.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;
        private readonly IPacienteService _pacienteService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogService _logService;

        public MedicamentoController(IMedicamentoService medicamentoService, IPacienteService pacienteService, IUsuarioService usuarioService, ILogService logService)
        {
            _medicamentoService = medicamentoService;
            _pacienteService = pacienteService;
            _usuarioService = usuarioService;
            _logService = logService;
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPost]
        public IActionResult Post([FromBody] MedicamentoCreateDTO medicamentoCreate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                var verificaSeExistePaciente = _pacienteService.GetById(medicamentoCreate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(medicamentoCreate.UsuarioId);
                if (verificaSeExistePaciente == null || verificaSeExisteUsuario == null)
                {
                    return NoContent();
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico" || tipo == "Enfermeiro")
                {
                    medicamentoCreate.UsuarioId = _id;
                }
                MedicamentoGetDTO medicamentoGet = _medicamentoService.CreateMedicamento(medicamentoCreate);


                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, cadastrou o medicamento de id {medicamentoGet.Id}.",
                    Dominio = "Medicamento-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Medicamento salvo com sucesso.", medicamentoGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }

        }


        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet]
        //public ActionResult<IEnumerable<MedicamentoGetDTO>> Get([FromQuery] int? pacienteId)
        public ActionResult<IEnumerable<MedicamentoGetDTO>> Get()
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

                IEnumerable<MedicamentoGetDTO> medicamentos = _medicamentoService.GetAllMedicamentos();

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, listou todos os pacientes do sistema.",
                    Dominio = "Medicamento-ObterTodos."
                };
                _logService.CreateLog(logModel);

                return Ok(medicamentos);

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]

        [HttpGet("{id}")]
        public ActionResult<MedicamentoGetDTO> Get([FromRoute] int id)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                MedicamentoGetDTO medicamentoGet = _medicamentoService.GetById(id);
                if (medicamentoGet == null)
                {
                    return NotFound("Medicamento não encontrado");
                }

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, listou o paciente de id {id}.",
                    Dominio = "Medicamento-obterPorId."
                };
                _logService.CreateLog(logModel);

                return Ok(medicamentoGet);

            }

            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno");
            }
        }

        [HttpGet("ByPaciente")]
        public ActionResult<IEnumerable<MedicamentoGetDTO>> Get([FromQuery] int? pacienteId)
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
                    var medicamentos = _medicamentoService.GetAllMedicamentos().Where(e => e.PacienteId == pacienteId.Value);


                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou dietas do paciente de id {pacienteId}.",
                        Dominio = "Medicamento-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(medicamentos);
                }
                else
                {
                    var medicamentos = _medicamentoService.GetAllMedicamentos();

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {id}, listou todas as dietas.",
                        Dominio = "Medicamento-obter."
                    };
                    _logService.CreateLog(logModel);

                    return Ok(medicamentos);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno");
            }
        }



        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public ActionResult<MedicamentoGetDTO> Update([FromRoute] int id, [FromBody] MedicamentoUpdateDTO medicamentoUpdate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                MedicamentoGetDTO? consultaNoSistema = _medicamentoService.GetById(id);
                if (consultaNoSistema == null)
                {
                    return NotFound("Medicamento não encontrado.");
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                if (tipo == "Médico" || tipo == "Enfermeiro")
                {
                    medicamentoUpdate.UsuarioId = _id;
                }

                var verificaSeExsitePaciente = _pacienteService.GetById(medicamentoUpdate.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(medicamentoUpdate.UsuarioId);
                if (verificaSeExisteUsuario == null || verificaSeExsitePaciente == null)
                {
                    return NoContent();
                }

                MedicamentoGetDTO medicamentoGet = _medicamentoService.UpdateMedicamento(medicamentoUpdate, id);


                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou o medicamento de id {id}.",
                    Dominio = "Medicamento-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(medicamentoGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno");
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

                bool remocao = _medicamentoService.DeleteMedicamento(id);
                if (remocao)
                {
                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, excluiu a dieta de id {id}.",
                        Dominio = "Medicamento-excluir."
                    };
                    _logService.CreateLog(logModel);
                    return Accepted();
                }
                return NotFound("Medicamento não encontrado");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno");
            }

        }
    }
}




