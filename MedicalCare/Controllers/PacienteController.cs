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

    }
}
