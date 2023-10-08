using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class EnderecoService
    {
        private readonly IDietaRepository _dietaRepository;

        public EnderecoService(IDietaRepository dietaRepository)
        {
            _dietaRepository = dietaRepository;
        }

        public async Task<IEnumerable<DietaModel>> GetAllEnderecosAsync()
        {
            return await _dietaRepository.GetAllDietasAsync();
        }

        public async Task<DietaModel> GetEnderecoByIdAsync(int id)
        {
            return await _dietaRepository.GetDietaByIdAsync(id);
        }

        public async Task<int> CreateEnderecoAsync(DietaModel dieta)
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
}
