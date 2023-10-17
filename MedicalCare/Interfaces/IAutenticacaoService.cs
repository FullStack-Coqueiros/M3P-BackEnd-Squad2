using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IAutenticacaoService
    {
        bool Autenticar(LoginDto loginDto);
    }
}