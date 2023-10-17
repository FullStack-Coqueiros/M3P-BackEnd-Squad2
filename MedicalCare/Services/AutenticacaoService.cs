using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Utils;

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
            return usuario.Senha == Criptografia.CriptografarSenha(loginDto.Senha); // Aqui retornará true caso
                                                                                    // as senhas coincidam ou false caso contrário. 
                                                                                    // Essa verificação se dá se for levado em conta
                                                                                    // que ao criar um novo usuário a senha já seja
                                                                                    // salva com criptografia.
        }

    }
}
