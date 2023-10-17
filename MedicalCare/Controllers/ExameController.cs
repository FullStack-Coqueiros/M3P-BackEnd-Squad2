using MedicalCare.DTO;
using MedicalCare.Interfaces;
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

        public ExameController(IExameService exameService)
        {
            _exameService = exameService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExameCreateDto exameCreate)
        {
            try
            {
                ExameGetDto exameGet = _exameService.CreateExame(exameCreate);
                return Created("Exame salvo com sucesso.", exameGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExameGetDto>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    // Retorna exames do paciente específico
                    var exames = _exameService.GetAllExames().Where(e => e.PacienteId == pacienteId.Value);
                    return Ok(exames);
                }
                else
                {
                    // Retorna todos os exames
                    var exames = _exameService.GetAllExames();
                    return Ok(exames);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ExameGetDto> Get([FromRoute] int id)
        {
            try
            {
                ExameGetDto exameGet = _exameService.GetById(id);
                if (exameGet == null)
                {
                    return NotFound("Id de exame não encontrado");
                }
                return Ok(exameGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ExameGetDto> Update([FromRoute] int id, [FromBody] ExameUpdateDto exameUpdate)
        {
            try
            {
                ExameGetDto? verificaSeExiste = _exameService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NotFound("Id de exame não encontrado.");
                }
                ExameGetDto exameGet = _exameService.UpdateExame(exameUpdate);
                return Ok(exameGet);
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
                bool remocao = _exameService.DeleteExame(id);
                if (remocao)
                {
                    return Accepted();
                }
                return NotFound("Id de exame não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
    }
}
