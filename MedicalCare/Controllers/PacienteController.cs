using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly ILogService _logService;
        private readonly IRepository<PacienteModel> _repository;

        public PacienteController(IPacienteService pacienteService, IRepository<PacienteModel> repository, ILogService logService)
        {
            _pacienteService = pacienteService;
            _repository = repository;
            _logService = logService;
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPost]
        public ActionResult<PacienteGetDto> Post([FromBody] PacienteCreateDto pacienteCreate)
        {
            var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
            if (!ativo) 
            {
                return BadRequest("Usuário inativo no sistema"); 
            }
            try
            {
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;
                int id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                bool verificaCpfEmail = _repository.GetByCpfEmail(pacienteCreate.Cpf, pacienteCreate.Email);
                if (verificaCpfEmail)
                {
                    return StatusCode(HttpStatusCode.Conflict.GetHashCode(), "Cpf e/ou email ja cadastrado(s).");
                }
                pacienteCreate.StatusDoSistema = true;
                PacienteGetDto pacienteGet = _pacienteService.CreatePaciente(pacienteCreate);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {id}, cadastrou o paciente {pacienteCreate.NomeCompleto} no sistema.",
                    Dominio = "Paciente-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Paciente salvo com sucesso.", pacienteGet);

            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet]
        public ActionResult<IEnumerable<PacienteGetDto>> Get()
        {
            try
            {
                IEnumerable<PacienteGetDto> pacientes = _pacienteService.GetAllPacientes();
                return Ok(pacientes);
            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet("{id}")]
        public ActionResult<PacienteGetDto> Get([FromRoute] int id)
        {
            try
            {
                PacienteGetDto pacienteGet = _pacienteService.GetById(id);
                if (pacienteGet == null)
                {
                    return NoContent();
                }
                return Ok(pacienteGet);
            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public ActionResult<PacienteGetDto> Update([FromRoute] int id, [FromBody] PacienteUpdateDto pacienteUpdate)
        {
            try
            {
                PacienteGetDto verificaSeExiste = _pacienteService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NoContent();
                }
                PacienteGetDto pacienteGet = _pacienteService.UpdatePaciente(pacienteUpdate, id);
                return Ok(pacienteGet);

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
                bool remocao = _pacienteService.DeletePaciente(id);
                if (remocao)
                {
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
