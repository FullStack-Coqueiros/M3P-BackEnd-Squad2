using MedicalCare.DTO;
using MedicalCare.Enums;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILoginService _loginService;
        private readonly ILogService _logService;


        public UsuarioController(IUsuarioService usuarioService, ILoginService loginService, ILogService logService)
        {
            _usuarioService = usuarioService;
            _loginService = loginService;
            _logService = logService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] TentativaLoginDto tentativaLogin)
        {
            try
            {
                if (_loginService.Login(tentativaLogin) == false)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Não foi possível logar.");
                }

                tentativaLogin.Logado = true;

                string tokenJwt = _loginService.GeraTokenJWT(tentativaLogin);
                return Ok(new {Token = tokenJwt});
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [AllowAnonymous]
        [HttpPost("login/resetarsenha")]
        public ActionResult<TentativaTrocaDeSenhaDto> ResetarSenha([FromBody] TentativaTrocaDeSenhaDto tentativaTrocaDeSenha)
        {
            try
            {
                string novaSenha = _loginService.GeraNovaSenha(tentativaTrocaDeSenha);
                if (novaSenha == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "email não cadastrado.");
                }

                tentativaTrocaDeSenha.SenhaNova = novaSenha;
                tentativaTrocaDeSenha.SenhaAntiga = null;
                return StatusCode(HttpStatusCode.OK.GetHashCode(), tentativaTrocaDeSenha);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }

        }


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult<UsuarioGetDto> Post([FromBody] UsuarioCreateDto usuarioCreate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }

                bool verificaCpfEmail = _usuarioService.GetAllUsuarios()
                                .Any(a => a.Cpf == usuarioCreate.Cpf || a.Email == usuarioCreate.Email);
                if (verificaCpfEmail)
                {
                    return StatusCode(HttpStatusCode.Conflict.GetHashCode(), "Cpf e/ou email ja cadastrado(s).");
                }

                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                usuarioCreate.StatusDoSistema = true;
                UsuarioGetDto usuarioGet = _usuarioService.CreateUsuario(usuarioCreate);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, cadastrou o usuário de id {usuarioGet.Id}.",
                    Dominio = "Usuario-cadastro."
                };
                _logService.CreateLog(logModel);

                return Created("Usuario salvo com sucesso.", usuarioGet);

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioGetDto>> Get()
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                IEnumerable<UsuarioGetDto> usuarios = _usuarioService.GetAllUsuarios();

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, listou todos os usuários.",
                    Dominio = "Usuario-obter."
                };
                _logService.CreateLog(logModel);

                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public ActionResult<UsuarioGetDto> Get([FromRoute] int id)
        {
            try
            {

                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                UsuarioGetDto usuarioGet = _usuarioService.GetById(id);
                if (usuarioGet == null)
                {
                    return NoContent();
                }

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, listou o usuário de id {id}.",
                    Dominio = "Usuario-obter."
                };
                _logService.CreateLog(logModel);

                return Ok(usuarioGet);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public ActionResult<UsuarioGetDto> Update([FromRoute] int id, [FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                UsuarioGetDto verificaSeExiste = _usuarioService.GetById(id);
                if (verificaSeExiste == null)
                {
                    return NoContent();
                }
                UsuarioGetDto usuarioGet = _usuarioService.UpdateUsuario(usuarioUpdate, id);

                LogModel logModel = new LogModel
                {
                    Descricao = $"{tipo} {nome}, de Id {_id}, atualizou o usuário de id {usuarioGet.Id}.",
                    Dominio = "Usuario-atualizar."
                };
                _logService.CreateLog(logModel);

                return Ok(usuarioGet);

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno.");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Aqui criar var pegando o id do adm logado, e barrar caso queira excluir ele mesmo.
            try
            {
                var ativo = bool.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StatusDoSistema").Value);
                if (!ativo)
                {
                    return BadRequest("Usuário inativo no sistema");
                }
                int _id = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                if(_id == id)
                {
                    return NoContent();
                }

                bool remocao = _usuarioService.DeleteUsuario(id);
                if (remocao)
                {
                    var nome = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Nome").Value;
                    var tipo = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tipo").Value;

                    LogModel logModel = new LogModel
                    {
                        Descricao = $"{tipo} {nome}, de Id {_id}, excluiu o usuário de id {id}.",
                        Dominio = "Usuario-excluir."
                    };
                    _logService.CreateLog(logModel);

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