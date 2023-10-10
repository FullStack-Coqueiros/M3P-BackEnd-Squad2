﻿using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public UsuarioGetDto UpdateUsuario(UsuarioUpdateDto usuario)
        {
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            _usuarioRepository.Update(usuarioModel);
            UsuarioGetDto usuarioGet = _mapper.Map<UsuarioGetDto>(usuario);
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