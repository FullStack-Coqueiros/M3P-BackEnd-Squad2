using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepository<EnderecoModel> _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IRepository<EnderecoModel> enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public IEnumerable<EnderecoModel> GetAllEnderecos()
        {
            return _enderecoRepository.GetAll();
        }

        public EnderecoModel GetById(int id)
        {
            return _enderecoRepository.GetById(id);
        }

        public EnderecoGetDto GetByRelationship (PacienteModel relationship)
        {
            EnderecoModel enderecoModel = GetAllEnderecos()
                .Where(a => a.PacienteId == relationship.Id).FirstOrDefault();
            EnderecoGetDto enderecoGet = _mapper.Map<EnderecoGetDto>(enderecoModel);
            return enderecoGet;
        }

        public EnderecoGetDto CreateEndereco(EnderecoCreateDto endereco)
        {
            EnderecoModel enderecoModel = _mapper.Map<EnderecoModel>(endereco);
             _enderecoRepository.Create(enderecoModel);
            EnderecoGetDto enderecoGet = _mapper.Map<EnderecoGetDto>(enderecoModel);
            return enderecoGet;
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
