using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;
        
        public ExercicioController(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExercicioCreateDto exercicioCreate)
        {
            try
            {
                ExercicioGetDto exercicioGet = _exercicioService.CreateExercicio(exercicioCreate);
                return Created("Exercicio salvo com sucesso", exercicioGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }
        [HttpPut("{id}")]
        public ActionResult<ExercicioGetDto> Update([FromRoute] int id, [FromBody] ExercicioUpdateDto exercicioUpdate)
        {
            try
            {
                ExercicioGetDto? consultaNoSistema = _exercicioService.GetById(id);
                if(consultaNoSistema == null)
                {
                    return NotFound("Exercicio não encontrado");
                    
                }
                ExercicioGetDto exercicioGet = _exercicioService.UpdateExercicio(exercicioUpdate);
                return Ok(exercicioGet);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExercicioGetDto>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                if(pacienteId.HasValue)
                {
                    var exercicios = _exercicioService.GetAllExercicios().Where(e => e.PacienteId == pacienteId.Value);
                    return Ok (exercicios);
                }
                else
                {
                    var exercicios = _exercicioService.GetAllExercicios();
                    return Ok(exercicios);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ExercicioGetDto>GetExercicio([FromRoute] int id)
        {
            try
            {
                ExercicioGetDto exercicioGet = _exercicioService.GetById(id);
                if(exercicioGet == null)
                {
                    return NotFound("Exercicio não encontrado");
                }
                return Ok(exercicioGet);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
        /* [HttpGet("ByPaciente")]
        public ActionResult<IEnumerable<ExercicioGetDto>> GetExerciciosByPaciente([FromQuery] int? pacienteId, [FromBody] bool isSomeFlagSet)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    var exercicios = _exercicioService.GetExerciciosByPaciente(pacienteId.Value, isSomeFlagSet);
                    return Ok(exercicios);
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
        } */


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                bool remocao = _exercicioService.DeleteExercicio(id);
                if (remocao)
                {
                    return Accepted();
                }
                return NotFound("Exercício não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
    }
}

        

