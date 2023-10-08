using MedicalCare.Interfaces;
using MedicalCare.Models;
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var enderecos = _enderecoService.GetAllEnderecos();
            return Ok(enderecos);
        }

        [HttpPost]
        public IActionResult Post([FromBody]EnderecoModel enderecoCreate)
        {
            var enderecoModel = _enderecoService.CreateEndereco(enderecoCreate);
            return Ok(enderecoModel);
        }
    }
}
