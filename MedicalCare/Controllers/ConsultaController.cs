using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsultaCreateDTO consultaCreate)
        {
            try
            {
                ConsultaGetDto consultaGet = _consultaService.CreateConsulta(consultaCreate);
                return Created("Consulta salvo com sucesso.",consultaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConsultaGetDto>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    // Retorna consultas do paciente específico
                    var consultas = _consultaService.GetAllConsultas().Where(e => e.PacienteId == pacienteId.Value);
                    return Ok(consultas);
                }
                else
                {
                    // Retorna todos as consultas
                    var consultas = _consultaService.GetAllConsultas();
                    return Ok(consultas);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ConsultaGetDto> Update([FromRoute] int id, [FromBody] ConsultaUpdateDTO consultaUpdate)
        {
            try
            {
                ConsultaGetDto verificaSeExiste = _consultaService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NotFound("Id de consulta não encontrada");
                }
                ConsultaGetDto consultaGet = _consultaService.UpdateConsulta(consultaUpdate);
                return Ok(consultaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode() ,ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ConsultaGetDto> GetConsulta([FromRoute] int id)
        {
            try
            {
                ConsultaGetDto consultaGet = _consultaService.GetById(id);
                if (consultaGet == null)
                {
                    return NotFound("Id de consulta não encontrada.");
                }
                return Ok(consultaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex);
            }
        }

        [HttpGet("ByPaciente")]
        public ActionResult<IEnumerable<ConsultaGetDto>> GetConsultasByPaciente([FromQuery] int? pacienteId, [FromBody] bool isSomeFlagSet)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    var consultas = _consultaService.GetConsultasByPaciente(pacienteId.Value, isSomeFlagSet);
                    return Ok(consultas);
                }
                else
                {
                    return BadRequest("O ID do paciente é obrigatório.");
                }
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
                bool remocao = _consultaService.DeleteConsulta(id);
                if (remocao)
                {
                    return Accepted();
                }
                return NotFound("Id de consulta não encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
    }
}
