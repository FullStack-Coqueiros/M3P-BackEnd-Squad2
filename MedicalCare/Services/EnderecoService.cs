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

        public IEnumerable<EnderecoModel> GetAllEnderecos() //Alterar retorno para GetDto
        {
            return _enderecoRepository.GetAll();
        }

        public EnderecoModel GetById(int id) //Alterar retorno para GetDto
        {
            return _enderecoRepository.GetById(id);
        }

        public EnderecoGetDto GetByRelationship (int id)
        {
            EnderecoModel enderecoModel = GetAllEnderecos()
                .Where(a => a.PacienteId == id).FirstOrDefault();
            EnderecoGetDto enderecoGet = _mapper.Map<EnderecoGetDto>(enderecoModel);
            return enderecoGet;
        }

        public EnderecoGetDto CreateEndereco(EnderecoCreateDto endereco)
        {
            EnderecoModel enderecoModel = _mapper.Map<EnderecoModel>(endereco);
             _enderecoRepository.Create(enderecoModel);
            EnderecoGetDto enderecoGet = GetByRelationship(enderecoModel.PacienteId);
            return enderecoGet;
        }

        public EnderecoGetDto UpdateEndereco(EnderecoUpdateDto endereco, int id)
        {
            EnderecoModel enderecoModel = GetById(id);

            enderecoModel = _mapper.Map(endereco, enderecoModel);
             _enderecoRepository.Update(enderecoModel);

            EnderecoGetDto enderecoGet = _mapper.Map<EnderecoGetDto>(enderecoModel);
            return enderecoGet;
        }

        public bool DeleteEndereco(int id)
        {
            return  _enderecoRepository.Delete(id);
        }

    }
}
