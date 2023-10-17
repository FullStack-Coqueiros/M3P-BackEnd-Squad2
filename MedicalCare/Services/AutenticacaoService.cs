using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioService _usuarioService;


        public AutenticacaoService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public bool Autenticar(LoginDto loginDto)
        {
            UsuarioModel usuario = _usuarioService.GetByEmail(loginDto.Email);
            if (usuario == null)
            {
                return false;
            }
            // return usuario.Senha 
        }

    }
}
