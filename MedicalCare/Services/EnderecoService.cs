using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class EnderecoService 
    {
        private readonly IRepository<EnderecoModel> _enderecoRepository;

        public EnderecoService(IRepository<EnderecoModel> enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IEnumerable<EnderecoModel> GetAllUsuarios()
        {
            return _enderecoRepository.GetAll();
        }

        public EnderecoModel GetById(int id)
        {
            return _enderecoRepository.GetById(id);
        }

        public EnderecoModel CreateUsuario(EnderecoModel endereco)
        {
            return _enderecoRepository.Create(endereco);
            //fazer mapper antes de retornar
        }

        public EnderecoModel UpdateUsuario(EnderecoModel endereco)
        {
            return _enderecoRepository.Update(endereco);
        }

        public bool DeleteUsuario(int id)
        {
            return  _enderecoRepository.Delete(id);
        }

    }
}
