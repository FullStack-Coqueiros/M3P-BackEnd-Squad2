using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
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
        private readonly IRepository<PacienteModel> _repository;

        public PacienteController(IPacienteService pacienteService, IRepository<PacienteModel> repository)
        {
            _pacienteService = pacienteService;
            _repository = repository;
        }


        [HttpPost]
        public ActionResult<PacienteGetDto> Post([FromBody] PacienteCreateDto pacienteCreate)
        {
            try
            {
                bool verificaCpfEmail = _repository.GetByCpfEmail(pacienteCreate.Cpf, pacienteCreate.Email);
                if (verificaCpfEmail)
                {
                    return StatusCode(HttpStatusCode.Conflict.GetHashCode(), "Cpf e/ou email ja cadastrado(s).");
                }
                pacienteCreate.StatusDoSistema = true;
                PacienteGetDto pacienteGet = _pacienteService.CreatePaciente(pacienteCreate);
                return Created("Paciente salvo com sucesso.", pacienteGet);

            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<PacienteGetDto>> Get()
        {
            try
            {
                IEnumerable<PacienteGetDto> pacientes = _pacienteService.GetAllPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PacienteGetDto> Get([FromRoute] int id)
        {
            try
            {
                PacienteGetDto pacienteGet = _pacienteService.GetById(id);
                if (pacienteGet == null)
                {
                    return NotFound("Id de paciente não encontrado.");
                }
                return Ok(pacienteGet);
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<PacienteGetDto> Update([FromRoute] int id, [FromBody] PacienteUpdateDto pacienteUpdate)
        {
            try
            {
                PacienteGetDto verificaSeExiste = _pacienteService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NotFound("Id de paciente não encontrado.");
                }
                PacienteGetDto pacienteGet = _pacienteService.UpdatePaciente(pacienteUpdate, id);
                return Ok(pacienteGet);

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

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
                return NotFound("Id de paciente não encontrado.");

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }



    }
}
