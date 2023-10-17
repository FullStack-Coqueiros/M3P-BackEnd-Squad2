using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioGetDto CreateUsuario(UsuarioCreateDto usuario);
        bool DeleteUsuario(int id);
        IEnumerable<UsuarioGetDto> GetAllUsuarios();
        UsuarioGetDto GetById(int id);
        UsuarioModel GetByEmail(string email);
        UsuarioGetDto UpdateUsuario(UsuarioUpdateDto usuario);
    }
}