using MedicalCare.Interfaces;
using MedicalCare.Models;

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

        public EnderecoModel GetById(int id)
        {
            return _enderecoRepository.GetById(id);
        }

        public EnderecoModel CreateEndereco(EnderecoModel endereco)
        {
            return _enderecoRepository.Create(endereco);
            //fazer mapper antes de retornar
        }

        public EnderecoModel UpdateEndereco(EnderecoModel endereco)
        {
            return _enderecoRepository.Update(endereco);
        }

        public bool DeleteEndereco(int id)
        {
            return  _enderecoRepository.Delete(id);
        }

    }
}
