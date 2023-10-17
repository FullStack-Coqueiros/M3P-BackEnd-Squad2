
using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;



namespace MedicalCare.Services
{
    public class ExameService : IExameService
    {
        private readonly IRepository<ExameModel> _exameRepository;
        private readonly IMapper _mapper;

        public ExameService(IMapper mapper, IRepository<ExameModel> exameRepository)
        {
            _mapper = mapper;
            _exameRepository = exameRepository;
        }

        public IEnumerable<ExameGetDto> GetAllExames()
        {
            IEnumerable<ExameModel> exames = _exameRepository.GetAll();
            IEnumerable<ExameGetDto> exameGet = _mapper.Map<IEnumerable<ExameGetDto>>(exames);
            return exameGet;
        }

        public ExameGetDto GetById(int id)
        {
            ExameModel exame = _exameRepository.GetById(id);
            ExameGetDto exameGetId = _mapper.Map<ExameGetDto>(exame);
            return exameGetId;
        }

        public ExameGetDto CreateExame(ExameCreateDto exame)
        {
            ExameModel exameModel = _mapper.Map<ExameModel>(exame);
            _exameRepository.Create(exameModel);
            ExameGetDto exameGet = _mapper.Map<ExameGetDto>(exame);
            return exameGet;
        }

        public ExameGetDto UpdateExame(ExameUpdateDto exame)
        {
            ExameModel exameModel = _mapper.Map<ExameModel>(exame);
            _exameRepository.Update(exameModel);
            ExameGetDto exameGet = _mapper.Map<ExameGetDto>(exame);
            return exameGet;
        }

        public IEnumerable<ExameGetDto> GetExamesByPaciente(int pacienteId)
        {
            IEnumerable<ExameModel> exames = _exameRepository.GetAll().Where(e => e.PacienteId == pacienteId);
            IEnumerable<ExameGetDto> exameGet = _mapper.Map<IEnumerable<ExameGetDto>>(exames);
            return exameGet;
        }

        public bool DeleteExame(int id)
        {
            bool remocao = _exameRepository.Delete(id);
            if (remocao)
            {
                return true;
            }
            return false;
        }

    }
}






