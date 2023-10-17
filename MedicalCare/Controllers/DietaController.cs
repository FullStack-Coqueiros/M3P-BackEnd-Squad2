using MedicalCare.DTO;
using MedicalCare.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaController : ControllerBase
    {
        private readonly IDietaService _dietaService;

        public DietaController(IDietaService dietaService)
        {
            _dietaService = dietaService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DietaCreateDto dietaCreateDto)
        {
            try
            {
                DietaGetDto dietaGet = _dietaService.CreateDieta(dietaCreateDto);
                return Created("Dieta salva com sucesso.", dietaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<DietaGetDto>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    bool isSomeOtherFlagSet = true; 
                    var dietas = _dietaService.GetDietasByPaciente(pacienteId.Value, isSomeOtherFlagSet);
                    return Ok(dietas);
                }
                else
                {
                    var dietas = _dietaService.GetAllDietas();
                    return Ok(dietas);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<DietaGetDto> Get([FromRoute] int id)
        {
            try
            {
                DietaGetDto dietaGet = _dietaService.GetById(id);
                if (dietaGet == null)
                {
                    return NotFound("Id de dieta não encontrado");
                }
                return Ok(dietaGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<DietaGetDto> Update([FromRoute] int id, [FromBody] DietaUpdateDto dietaUpdateDto)
        {
            try
            {
                DietaGetDto? verificaSeExiste = _dietaService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NotFound("Id de dieta não encontrado.");
                }
                DietaGetDto dietaGet = _dietaService.UpdateDieta(dietaUpdateDto);
                return Ok(dietaGet);
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
                bool remocao = _dietaService.DeleteDieta(id);
                if (remocao)
                {
                    return Accepted();
                }
                return NotFound("Id de dieta não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
    }
}
