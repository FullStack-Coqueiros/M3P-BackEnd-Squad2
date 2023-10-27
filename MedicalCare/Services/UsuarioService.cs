using System.Runtime.CompilerServices;
using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Enums;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MedicalCare.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<UsuarioModel> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IMapper mapper, IRepository<UsuarioModel> usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioGetDto GetByEmail(string email)
        {
            IEnumerable<UsuarioModel> usuarios = _usuarioRepository.GetAll().Where(x => x.Email == email);
            if (usuarios.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                UsuarioModel usuario = usuarios.First();
                return _mapper.Map<UsuarioGetDto>(usuario);
            }
        }

        public IEnumerable<UsuarioGetDto> GetAllUsuarios()
        {
            IEnumerable<UsuarioModel> usuarios = _usuarioRepository.GetAll();
            IEnumerable<UsuarioGetDto> usuarioGet = _mapper.Map<IEnumerable<UsuarioGetDto>>(usuarios);
            return usuarioGet;
        }

        public UsuarioGetDto GetById(int id)
        {
            UsuarioModel usuario = _usuarioRepository.GetById(id);
            UsuarioGetDto usuarioGetId = _mapper.Map<UsuarioGetDto>(usuario);
            return usuarioGetId;
        }

        public UsuarioGetDto CreateUsuario(UsuarioCreateDto usuario)
        {
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            usuarioModel.Genero = Enum.GetName(typeof(Egenero), usuario.Genero.GetHashCode());
            usuarioModel.Tipo = Enum.GetName(typeof(ETipo), usuario.Tipo.GetHashCode());
            _usuarioRepository.Create(usuarioModel);
            UsuarioModel usuarioModelComId = _usuarioRepository.GetAll().Where(x => x.Email == usuarioModel.Email).FirstOrDefault();
            UsuarioGetDto usuarioGet = _mapper.Map<UsuarioGetDto>(usuarioModelComId);
            return usuarioGet;
        }

        public UsuarioGetDto UpdateUsuario(UsuarioUpdateDto usuarioUpdate, int id)
        {
            UsuarioModel usuarioModel = _usuarioRepository.GetById(id);
            usuarioModel = _mapper.Map(usuarioUpdate, usuarioModel);
            Console.WriteLine(usuarioModel);
            _usuarioRepository.Update(usuarioModel);
            UsuarioModel usuarioModelAtualizado = _usuarioRepository.GetById(id);
            UsuarioGetDto usuarioGet = _mapper.Map<UsuarioGetDto>(usuarioModelAtualizado);
            return usuarioGet;
        }

        public bool DeleteUsuario(int id)
        {
            bool remocao = _usuarioRepository.Delete(id);
            if (remocao)
            {
                return true;
            }
            return false;
        }

    }
}