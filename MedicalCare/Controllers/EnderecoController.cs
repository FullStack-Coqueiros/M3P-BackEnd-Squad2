using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] EnderecoCreateDto enderecoCreate)
        {
            EnderecoGetDto enderecoGet = _enderecoService.CreateEndereco(enderecoCreate);
            return Ok(enderecoGet);
            //TODO: Refatorar aqui.
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var enderecos = _enderecoService.GetAllEnderecos();
            return Ok(enderecos);
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var endereco = _enderecoService.GetById(id);
            return Ok(endereco);
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] EnderecoUpdateDto enderecoUpdate)  //terminar essa controller
        {
            var enderecoModel = _enderecoService.GetById(id);
            if (enderecoModel == null)
            {
                return NotFound();
            }
            _enderecoService.UpdateEndereco(enderecoUpdate, id); 
            return Ok(enderecoUpdate);
        }

        [Authorize(Roles = "Administrador, Médico, Enfermeiro")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool response = _enderecoService.DeleteEndereco(id);
            if (response == false)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
