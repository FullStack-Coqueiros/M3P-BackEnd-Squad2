using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] TentativaLoginDto tentativaLogin)
        {
             try
            {
                if (_loginService.Login(tentativaLogin) == false) {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Não foi possível logar.");
                }

                tentativaLogin.Logado = true;

                string tokenJwt = _loginService.GeraTokenJWT(tentativaLogin);                
                return StatusCode(HttpStatusCode.OK.GetHashCode(), tokenJwt);   
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("login/resetarsenha")]
        public ActionResult<TentativaTrocaDeSenhaDto> ResetarSenha([FromBody] TentativaTrocaDeSenhaDto tentativaTrocaDeSenha)
        {
            try
            {
                string novaSenha = _loginService.GeraNovaSenha(tentativaTrocaDeSenha);
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


        [Authorize(Roles = "Administrador")]
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
                return Created("Usuario salvo com sucesso.", usuarioGet);

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public ActionResult<UsuarioGetDto> Update([FromRoute] int id, [FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            //Aqui criar var pegando o id do adm logado, e barrar caso queira inativar ele mesmo.
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

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Aqui criar var pegando o id do adm logado, e barrar caso queira excluir ele mesmo.
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