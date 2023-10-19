using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicalCare.Services
{
    public class LoginService : ILoginService
    {
        const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private IUsuarioService usuarios;

        private Random random;
        
        public LoginService(IUsuarioService usuarios)
        {
            this.usuarios = usuarios;
            this.random = new Random();
        }

        public bool Login(TentativaLoginDto login)
        {
            UsuarioGetDto usuario = this.usuarios.GetByEmail(login.Email);
            if (usuario == null) {
                //console.log("e-mail inválido")
                return false;
            } else {
                if (usuario.Senha != login.Senha) {
                    //console.log("as senhas não batem.")
                    return false;
                }
            }

            return true;        
        }

        public int GeraTokenJWT(TentativaLoginDto login) {
            return 0;
        }

        public string GeraNovaSenha(TentativaTrocaDeSenhaDto tentativa) {
            UsuarioGetDto usuario = this.usuarios.GetByEmail(tentativa.Email);
            if (usuario == null) {
                //console.log("e-mail inválido")
                return null;
            }

            // refatorar isso aqui num utils.
            return new string(Enumerable.Repeat(CHARS, 12).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}