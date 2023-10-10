using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class UsuarioService
    {
        private readonly IRepository<UsuarioModel> _usuarioRepository;

        public UsuarioService(IRepository<UsuarioModel> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioModel> GetAllUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        public UsuarioModel GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }

        public UsuarioModel CreateUsuario(UsuarioModel endereco)
        {
            return _usuarioRepository.Create(endereco);
            //fazer mapper antes de retornar
        }

        public UsuarioModel UpdateUsuario(UsuarioModel endereco)
        {
            return _usuarioRepository.Update(endereco);
        }

        public bool DeleteUsuario(int id)
        {
            return _usuarioRepository.Delete(id);
        }

    }