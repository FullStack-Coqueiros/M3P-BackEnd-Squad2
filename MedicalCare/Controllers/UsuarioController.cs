using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILoginService _loginService;

        public UsuarioController(IUsuarioService usuarioService, ILoginService loginService)
        {
            _usuarioService = usuarioService;
            _loginService = loginService;
        }


        [HttpPost("login")]
        // esse é o retorno certo do controller?
        public ActionResult<UsuarioGetDto> Login([FromBody] TentativaLoginDto tentativaLogin)
        {
             try
            {
                if (_loginService.Login(tentativaLogin) == false) {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Não foi possível logar.");
                }

                tentativaLogin.Logado = true;

                // TODO: colocar código no método de gerar a token JWT
                int tokenJwt = _loginService.GeraTokenJWT(tentativaLogin);                
                return StatusCode(HttpStatusCode.OK.GetHashCode(), tokenJwt);   
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
        
    
        [HttpPost("login/resetarsenha")]
        public ActionResult<TentativaTrocaDeSenhaDto> ResetarSenha([FromBody] TentativaTrocaDeSenhaDto tentativaTrocaDeSenha)
        {
            try
            {
                String novaSenha = _loginService.GeraNovaSenha(tentativaTrocaDeSenha);
                if (novaSenha == null) {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "email não cadastrado.");
                }

                tentativaTrocaDeSenha.SenhaNova = novaSenha;
                tentativaTrocaDeSenha.SenhaAntiga = null;
                return StatusCode(HttpStatusCode.OK.GetHashCode(), tentativaTrocaDeSenha);
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }


        [HttpPost]
        public ActionResult<UsuarioGetDto> Post([FromBody] UsuarioCreateDto usuarioCreate)
        {
            try
            {
                bool verificaCpfEmail = _usuarioService.GetAllUsuarios()
                                .Any(a => a.Cpf == usuarioCreate.Cpf || a.Email == usuarioCreate.Email);
                if (verificaCpfEmail)
                {
                    return StatusCode(HttpStatusCode.Conflict.GetHashCode(), "Cpf e/ou email ja cadastrado(s).");
                }
                usuarioCreate.StatusDoSistema = true;
                UsuarioGetDto usuarioGet = _usuarioService.CreateUsuario(usuarioCreate);
                return Created("Usuário salvo com sucesso.", usuarioGet);

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioGetDto>> Get()
        {
            try
            {
                IEnumerable<UsuarioGetDto> usuarios = _usuarioService.GetAllUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioGetDto> Get([FromRoute] int id)
        {
            try
            {
                UsuarioGetDto usuarioGet = _usuarioService.GetById(id);
                if (usuarioGet == null)
                {
                    return NotFound("Id de usuário não encontrado.");
                }
                return Ok(usuarioGet);
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<UsuarioGetDto> Update([FromRoute] int id, [FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            try
            {
                UsuarioGetDto? verificaSeExiste = _usuarioService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NotFound("Id de usuário não encontrado.");
                }
                UsuarioGetDto usuarioGet = _usuarioService.UpdateUsuario(usuarioUpdate, id);
                return Ok(usuarioGet);

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
                bool remocao = _usuarioService.DeleteUsuario(id);
                if (remocao)
                {
                return Accepted();
                }
                return NotFound("Id de usuário não encontrado.");

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }



    }
}