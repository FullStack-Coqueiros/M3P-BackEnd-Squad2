using MedicalCare.DTO;
using MedicalCare.Interfaces;
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

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }


        [HttpPost]
        public ActionResult<PacienteGetDto> Post([FromBody] PacienteCreateDto pacienteCreate)
        {
            try
            {
                IEnumerable<PacienteGetDto> verificaCpfEmail = _pacienteService.GetAllPacientes()
                    .Where(w => w.Cpf == pacienteCreate.Cpf || w.Email == pacienteCreate.Email);
                if (verificaCpfEmail == null)
                {
                    pacienteCreate.StatusDoSistema = true;
                    PacienteGetDto pacienteGet = _pacienteService.CreatePaciente(pacienteCreate);
                    return Created("Paciente salvo com sucesso", pacienteGet);
                }
                return StatusCode(HttpStatusCode.Conflict.GetHashCode(), "Cpf e/ou email ja cadastrado(s).");

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
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
                //verificar se realmente alterou o se adicionou um novo.
                PacienteGetDto pacienteGet = _pacienteService.UpdatePaciente(pacienteUpdate);
                return Ok(pacienteGet);
                
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }





    }
}
