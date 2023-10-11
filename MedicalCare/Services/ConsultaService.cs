using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IRepository<ConsultaModel> _consultaRepository;
        private readonly IMapper _mapper;

        public ConsultaService(IMapper mapper, IRepository<ConsultaModel> consultaRepository)
        {
            _mapper = mapper;
            _consultaRepository = consultaRepository;
        }

        public IEnumerable<ConsultaGetDto> GetAllConsultas()
        {
            IEnumerable<ConsultaModel> consultas = _consultaRepository.GetAll();
            IEnumerable<ConsultaGetDto> consultaGet = _mapper.Map<IEnumerable<ConsultaGetDto>>(consultas);
            return consultaGet;
        }

        public ConsultaGetDto GetById(int id)
        {
            ConsultaModel consulta = _consultaRepository.GetById(id);
            ConsultaGetDto consultaGetId = _mapper.Map<ConsultaGetDto>(consulta);
            return consultaGetId;
        }

        public ConsultaGetDto CreateConsulta(ConsultaCreateDTO consulta)
        {
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consulta);
            _consultaRepository.Create(consultaModel);
            ConsultaGetDto consultaGet = _mapper.Map<ConsultaGetDto>(consulta);
            return consultaGet;
        }

        public ConsultaGetDto UpdateConsulta(ConsultaUpdateDTO consulta)
        {
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consulta);
            _consultaRepository.Update(consultaModel);
            ConsultaGetDto consultaGet = _mapper.Map<ConsultaGetDto>(consulta);
            return consultaGet;
        }

        public bool DeleteConsulta(int id)
        {
            bool remocao = _consultaRepository.Delete(id);
            if (remocao)
            {
                return true;
            }
            return false;
        }
    }
}
