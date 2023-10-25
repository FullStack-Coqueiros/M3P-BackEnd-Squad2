using MedicalCare.DTO;
using MedicalCare.Models;


namespace MedicalCare.Interfaces
{
    public interface IDietaService
    {
        DietaGetDto CreateDieta(DietaCreateDto dieta);
        DietaGetDto UpdateDieta(DietaUpdateDto dieta, int id);
        DietaGetDto GetById(int id);
        IEnumerable<DietaGetDto> GetAllDietas();
        bool DeleteDieta(int id);

        IEnumerable<DietaGetDto> GetDietasByPaciente(int pacienteId);

    }
}




