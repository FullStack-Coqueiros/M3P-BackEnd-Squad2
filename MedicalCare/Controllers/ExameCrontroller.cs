using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Mvc;


namespace MedicalCare.Controllers
{
   

    [ApiController]
    [Route("api/exames")]
    public class ExameController : ControllerBase
    {
        private readonly ExameService _exameService;

        public ExameController(ExameService exameService)
        {
            _exameService = exameService;
        }

        [HttpPost]
        public IActionResult CreateExame([FromBody] ExameModel exame)
        {
            var createdExame = _exameService.CreateExame(exame);
            return CreatedAtAction(nameof(GetExameById), new { id = createdExame.Id }, createdExame);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExame(int id, [FromBody] ExameModel exame)
        {
            var updatedExame = _exameService.UpdateExame(exame);
            if (updatedExame == null)
            {
                return NotFound("Exame não encontrado");
            }

            return Ok(updatedExame);
        }

        [HttpGet("{id}")]
        public IActionResult GetExameById(int id)
        {
            var exame = _exameService.GetExameById(id);
            if (exame == null)
            {
                return NotFound("Exame não encontrado");
            }

            return Ok(exame);
        }

        [HttpGet]
        public IActionResult GetAllExames()
        {
            var exames = _exameService.GetAllExames();
            return Ok(exames);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExame(int id)
        {
            var result = _exameService.DeleteExame(id);
            if (!result)
            {
                return NotFound("Exame não encontrado");
            }

            return NoContent();
        }
    }
}
