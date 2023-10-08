
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IDietaRepository
    {

        Task<IEnumerable<DietaModel>> GetAllDietasAsync();
        Task<DietaModel> GetDietaByIdAsync(int id);
        Task<int> CreateDietaAsync(DietaModel dieta);
        Task<bool> UpdateDietaAsync(DietaModel dieta);
        Task<bool> DeleteDietaAsync(int id);

    }
}
