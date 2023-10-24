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
        private readonly IPacienteService _pacienteService;
        private readonly IUsuarioService _usuarioService;

        public DietaController(IDietaService dietaService, IPacienteService pacienteService, IUsuarioService usuarioService)
        {
            _dietaService = dietaService;
            _pacienteService = pacienteService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DietaCreateDto dietaCreateDto)
        {
            try
            {
                var verificaSeExsitePaciente = _pacienteService.GetById(dietaCreateDto.PacienteId);
                var verificaSeExisteUsuario = _usuarioService.GetById(dietaCreateDto.UsuarioId);
                if (verificaSeExsitePaciente != null && verificaSeExisteUsuario != null)
                {
                DietaGetDto dietaGet = _dietaService.CreateDieta(dietaCreateDto);
                return Created("Dieta salva com sucesso.", dietaGet);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<DietaGetDto>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    var dietas = _dietaService.GetDietasByPaciente(pacienteId.Value);
                    return Ok(dietas);
                }
                else
                {
                    var dietas = _dietaService.GetAllDietas();
                    return Ok(dietas);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }
        //[HttpGet("{id}")]
        //public ActionResult<DietaGetDto> Get([FromRoute] int id)
        //{
        //    try
        //    {
        //        DietaGetDto dietaGet = _dietaService.GetById(id);
        //        if (dietaGet == null)
        //        {
        //            return NotFound("Id de dieta não encontrado");
        //        }
        //        return Ok(dietaGet);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
        //    }
        //}

        [HttpPut("{id}")]
        public ActionResult<DietaGetDto> Update([FromRoute] int id, [FromBody] DietaUpdateDto dietaUpdateDto)
        {
            try
            {
                DietaGetDto verificaSeExiste = _dietaService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NoContent();
                }
                DietaGetDto dietaGet = _dietaService.UpdateDieta(dietaUpdateDto);
                return Ok(dietaGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
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
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }
    }
}
