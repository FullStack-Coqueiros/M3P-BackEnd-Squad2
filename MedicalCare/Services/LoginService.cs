using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalCare.Services
{
    public class LoginService : ILoginService
    {
        const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private readonly IUsuarioService usuarios;

        private readonly Random random;
        private readonly string _chaveJwt;
        
        public LoginService(IUsuarioService usuarios, IConfiguration configuration)
        {
            this.usuarios = usuarios;
            this.random = new Random();
            _chaveJwt = configuration.GetSection("jwtTokenChave").Get<string>();
        }

        public bool Login(TentativaLoginDto login)
        {
            UsuarioGetDto usuario = this.usuarios.GetByEmail(login.Email);
            if (usuario == null) {
                return false;
            } else {
                if (usuario.Senha != login.Senha) {
                    return false;
                }
            }

            return true;        
        }

        public string GeraTokenJWT(TentativaLoginDto login)
         {
           UsuarioGetDto usuario = this.usuarios.GetByEmail(login.Email);

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

        public string GeraNovaSenha(TentativaTrocaDeSenhaDto tentativa) {
            UsuarioGetDto usuario = this.usuarios.GetByEmail(tentativa.Email);
            if (usuario == null) {
                return null;
            }

            return new string(Enumerable.Repeat(CHARS, 12).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}