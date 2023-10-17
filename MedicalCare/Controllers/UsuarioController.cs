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

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost("{Email}")]
        public ActionResult<UsuarioGetDto> Post([FromRoute] string Email, [FromBody] UsuarioCreateDto usuarioCreate)
        {
             try
            {
                bool verificaEmail = _usuarioService.GetAllUsuarios()
                                .Any(a => a.Email == usuarioCreate.Email);
                if (!verificaEmail)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "email não cadastrado.");
                }
                usuarioCreate.StatusDoSistema = true;
                return StatusCode(HttpStatusCode.OK.GetHashCode());   //token JWT
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
        
    
        [HttpPost("{Email}")]
        public ActionResult<UsuarioGetDto> Post([FromRoute] string Email, [FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            try
            {
                bool verificaEmail = _usuarioService.GetAllUsuarios()
                                .Any(a => a.Email == usuarioUpdate.Email);
                if (!verificaEmail)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "email não cadastrado.");
                }
                UsuarioGetDto usuarioGet = _usuarioService.UpdateUsuario(usuarioUpdate, Email);
                return Ok(usuarioGet);
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