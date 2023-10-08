using MedicalCare.Interfaces;
using MedicalCare.Models;
using MedicalCare.Repositoryes;

namespace MedicalCare.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepository<EnderecoModel> _enderecoRepository;

        public EnderecoService(IRepository<EnderecoModel> enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IEnumerable<EnderecoModel> GetAllEnderecos()
        {
            return _enderecoRepository.GetAll();
        }

        //public async Task<DietaModel> GetEnderecoByIdAsync(int id)
        //{
        //    return await _dietaRepository.GetDietaByIdAsync(id);
        //}

        public EnderecoModel CreateEndereco(EnderecoModel endereco)
        {
            return _enderecoRepository.Create(endereco);
            //fazer mapper antes de retornar
        }

        //public async Task<bool> UpdateDietaAsync(DietaModel dieta)
        //{
        //    return await _dietaRepository.UpdateDietaAsync(dieta);
        //}

        //public async Task<bool> DeleteDietaAsync(int id)
        //{
        //    return await _dietaRepository.DeleteDietaAsync(id);
        //}

    }
}
