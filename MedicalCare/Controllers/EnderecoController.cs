//using MedicalCare.Interfaces;
//using MedicalCare.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MedicalCare.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class EnderecoController : ControllerBase
//    {
//        private readonly IEnderecoService _enderecoService;

//        public EnderecoController(IEnderecoService enderecoService)
//        {
//            _enderecoService = enderecoService;
//        }
//        [HttpPost]
//        public IActionResult Post([FromBody]EnderecoModel enderecoCreate)
//        {
//            var enderecoModel = _enderecoService.CreateEndereco(enderecoCreate);
//            return Ok(enderecoModel);
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var enderecos = _enderecoService.GetAllEnderecos();
//            return Ok(enderecos);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById([FromRoute] int id)
//        {
//            var endereco = _enderecoService.GetById(id);
//            return Ok(endereco);
//        }

//        [HttpPut("{id}")]
//        public IActionResult Update([FromRoute] int id, [FromBody] EnderecoModel enderecoUpdate)
//        {
//            var enderecoModel = _enderecoService.GetById(id);
//            if (enderecoModel == null)
//            {
//                return NotFound();
//            }
//            _enderecoService.UpdateEndereco(enderecoUpdate);
//            return Ok(enderecoUpdate);
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete([FromRoute] int id)
//        {
//           bool response = _enderecoService.DeleteEndereco(id);
//           if(response == false)
//            {
//                return NotFound();
//            }
//            return Ok();

//        }
//    }
//}
