using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalCare.Models;
using MedicalCare.Interfaces;

public class DietaService
{
    private readonly IDietaRepository _dietaRepository;

    public DietaService(IDietaRepository dietaRepository)
    {
        _dietaRepository = dietaRepository;
    }

    public async Task<IEnumerable<DietaModel>> GetAllDietasAsync()
    {
        return await _dietaRepository.GetAllDietasAsync();
    }

    public async Task<DietaModel> GetDietaByIdAsync(int id)
    {
        return await _dietaRepository.GetDietaByIdAsync(id);
    }

    public async Task<int> CreateDietaAsync(DietaModel dieta)
    {
        return await _dietaRepository.CreateDietaAsync(dieta);
    }

    public async Task<bool> UpdateDietaAsync(DietaModel dieta)
    {
        return await _dietaRepository.UpdateDietaAsync(dieta);
    }

    public async Task<bool> DeleteDietaAsync(int id)
    {
        return await _dietaRepository.DeleteDietaAsync(id);
    }
}
