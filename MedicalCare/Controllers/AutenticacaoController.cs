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
            if (!_autenticacaoService.Autenticar(loginDto)) return Unauthorized("Usuário e/ou senha inválido(s).");
            string token = _autenticacaoService.GerarToken(loginDto);
            return Ok(token);
            
        }


    }
}
