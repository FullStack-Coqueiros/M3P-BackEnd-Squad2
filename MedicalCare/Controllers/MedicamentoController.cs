using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalCare.DTO;
using MedicalCare.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicalCare.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;
        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        //[Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPost]
        public IActionResult Post([FromBody] MedicamentoCreateDTO medicamentoCreate)
        {
            MedicamentoGetDTO medicamentoGet = _medicamentoService.CreateMedicamento(medicamentoCreate);
            return Created("Medicamento salvo com sucesso.", medicamentoGet);

        }
        [HttpGet]
        public ActionResult<IEnumerable<MedicamentoGetDTO>> Get()
        {
            try
            {
                IEnumerable<MedicamentoGetDTO> medicamentos = _medicamentoService.GetAllMedicamentos();
                return Ok(medicamentos);
            }

            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet("ByPaciente")]
        public ActionResult<IEnumerable<MedicamentoGetDTO>> Get([FromQuery] int? pacienteId)
        {
            try
            {
                if (pacienteId.HasValue)
                {
                    var medicamentos = _medicamentoService.GetAllMedicamentos().Where(e => e.PacienteId == pacienteId.Value);
                    return Ok(medicamentos);
                }
                else
                {
                    var medicamentos = _medicamentoService.GetAllMedicamentos();
                    return Ok(medicamentos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }


        //[Authorize(Roles = "Administrador, Médico, Enfermeiro")]

        [HttpGet("{id}")]
        public ActionResult<MedicamentoGetDTO> Get([FromRoute] int id)
        {
            try
            {
                MedicamentoGetDTO medicamentoGet = _medicamentoService.GetById(id);
                if (medicamentoGet == null)
                {
                    return NotFound("Medicamento não encontrado");
                }
                return Ok(medicamentoGet);

            }

            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        //[Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public ActionResult<MedicamentoGetDTO> Update([FromRoute] int id, [FromBody] MedicamentoUpdateDTO medicamentoUpdate)
        {
            try
            {
                MedicamentoGetDTO? consultaNoSistema = _medicamentoService.GetById(id);
                if (consultaNoSistema == null)
                {
                    return NotFound("Medicamento não encontrado.");
                }
                MedicamentoGetDTO medicamentoGet = _medicamentoService.UpdateMedicamento(medicamentoUpdate, id);
                return Ok(medicamentoGet);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        //[Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpDelete("{id}")]

        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                bool remocao = _medicamentoService.DeleteMedicamento(id);
                if (remocao)
                {
                    return Accepted();
                }
                return NotFound("Medicamento não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }
    }
}




