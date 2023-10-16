using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            ConsultaGetDto consultaGet = _consultaService.CreateConsulta(consultaCreate);
            return Created("Consulta salvo com sucesso.",consultaGet);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConsultaGetDto>> Get()
        {
            try
            {
                IEnumerable<ConsultaGetDto> consultas = _consultaService.GetAllConsultas();
                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex);
            }
            //var consultas = _consultaService.GetAllConsultas();
            //return Ok(consultas);
        }

        [HttpGet("{id}")]
        public ActionResult<ConsultaGetDto> Get([FromRoute] int id)
        {
            try
            {
                ConsultaGetDto consultaGet = _consultaService.GetById(id);
                if (consultaGet == null)
                {
                    return NotFound("Id de consulta não encontrada");
                }
                return Ok(consultaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode() ,ex);
            }
            //var consulta = _consultaService.GetById(id);
            //return Ok(consulta);
        }

        [HttpPut("{id}")]
        public ActionResult<ConsultaGetDto> Update([FromRoute] int id, [FromBody] ConsultaUpdateDTO consultaUpdate)
        {
            try
            {
                ConsultaGetDto? verificaSeExiste = _consultaService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NotFound("Id de consulta não encontrada.");
                }
                ConsultaGetDto consultaGet = _consultaService.UpdateConsulta(consultaUpdate, id);
                return Ok(consultaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex);
            }
            //var consultaModel = _consultaService.GetById(id);
            //if (consultaModel == null)
            //{
            //    return NotFound();
            //}
            //_consultaService.UpdateConsulta(consultaUpdate);
            //return Ok(consultaUpdate);
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
