using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Services
{
    public class UsuarioService
    {
        private readonly IRepository<UsuarioModel> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IMapper mapper, IRepository<UsuarioModel> usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
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
            _usuarioRepository.Create(usuarioModel);
            UsuarioGetDto usuarioGet = _mapper.Map<UsuarioGetDto>(usuario);
            return usuarioGet;
        }

        public UsuarioModel UpdateUsuario(UsuarioModel usuario)
        {
            return _usuarioRepository.Update(endereco);
        }

        public bool DeleteUsuario(int id)
        {
            return _usuarioRepository.Delete(id);
        }

    }
}