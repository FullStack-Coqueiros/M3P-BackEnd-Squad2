using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public ConsultaGetDto CreateConsulta(ConsultaCreateDTO consultaCreate)
        {
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consultaCreate);
            _consultaRepository.Create(consultaModel);
            ConsultaGetDto consultaGet = _mapper.Map<ConsultaGetDto>(consultaCreate);
            return consultaGet;
        }

        public ConsultaGetDto UpdateConsulta(ConsultaUpdateDTO consultaUpdate, int id)
        {
            ConsultaModel consultaModel = _consultaRepository.GetById(id);
            consultaModel = _mapper.Map(consultaUpdate, consultaModel);
            _consultaRepository.Update(consultaModel);
            ConsultaModel consultaModelAtualizado = _consultaRepository.GetById(id);
            ConsultaGetDto consultaGet = _mapper.Map<ConsultaGetDto>(consultaModelAtualizado);
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
