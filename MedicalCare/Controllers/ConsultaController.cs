using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(consultaGet);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var consultas = _consultaService.GetAllConsultas();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var consulta = _consultaService.GetById(id);
            return Ok(consulta);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ConsultaUpdateDTO consultaUpdate)
        {
            var consultaModel = _consultaService.GetById(id);
            if (consultaModel == null)
            {
                return NotFound();
            }
            _consultaService.UpdateConsulta(consultaUpdate);
            return Ok(consultaUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool response = _consultaService.DeleteConsulta(id);
            if (response == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
