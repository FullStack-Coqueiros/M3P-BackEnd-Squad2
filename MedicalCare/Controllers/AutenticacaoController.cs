using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;


        public AutenticacaoController (IAutenticacaoService service)
        {
            _autenticacaoService = service;
        }

        [HttpPost("Logar")]
        public ActionResult Logar([FromBody] LoginDto loginDto)
        {
            bool autenticacao= _autenticacaoService.Autenticar(loginDto);
            if (autenticacao)
            {
                return Ok(); //terminar aqui
            }
            return Ok(); //terminar aqui

        }


    }
}
