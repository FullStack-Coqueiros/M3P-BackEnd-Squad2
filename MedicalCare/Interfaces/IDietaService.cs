using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IDietaService
    {
        Task<IEnumerable<DietaModel>> GetAllDietasAsync();
        DietaModel GetById(int id);
        DietaModel Create(DietaModel dieta);
        DietaModel Update(DietaModel dieta);
        bool Delete(int id);


    }
}
