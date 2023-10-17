using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalCare.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly string _chaveJwt;


        public AutenticacaoService(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _chaveJwt = configuration.GetSection("jwtTokenChave").Get<string>();
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

        public string GerarToken (LoginDto loginDto)
        {
            UsuarioModel usuario = _usuarioService.GetByEmail(loginDto.Email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_chaveJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim("Nome", usuario.NomeCompleto),
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
