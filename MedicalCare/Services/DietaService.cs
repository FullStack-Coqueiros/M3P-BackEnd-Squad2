
using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Enums;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MedicalCare.Services

{
    public class DietaService : IDietaService
    {
        private readonly IRepository<DietaModel> _dietaRepository;
        private readonly IMapper _mapper;

        public DietaService(IMapper mapper, IRepository<DietaModel> dietaRepository)
        {
            _mapper = mapper;
            _dietaRepository = dietaRepository;
        }

        public IEnumerable<DietaGetDto> GetAllDietas()
        {
            IEnumerable<DietaModel> dietas = _dietaRepository.GetAll();
            IEnumerable<DietaGetDto> dietaGet = _mapper.Map<IEnumerable<DietaGetDto>>(dietas);
            return dietaGet;
        }

        public DietaGetDto GetById(int id)
        {
            DietaModel dieta = _dietaRepository.GetById(id);
            DietaGetDto dietaGetId = _mapper.Map<DietaGetDto>(dieta);
            return dietaGetId;
        }
        public IEnumerable<DietaGetDto> GetDietasByPaciente(int pacienteId)
        {
            IEnumerable<DietaModel> dietas = _dietaRepository.GetAll().Where(d => d.PacienteId == pacienteId);
            IEnumerable<DietaGetDto> dietaGet = _mapper.Map<IEnumerable<DietaGetDto>>(dietas);
            return dietaGet;
        }


        public DietaGetDto CreateDieta(DietaCreateDto dietaCreate)
        {
            DietaModel dietaModel = _mapper.Map<DietaModel>(dietaCreate);
            dietaModel.Tipo = Enum.GetName(typeof(ETipoDieta), dietaCreate.Tipo.GetHashCode());
            _dietaRepository.Create(dietaModel);
            DietaGetDto dietaGet = GetAllDietas()
                .FirstOrDefault(w => w.Data == dietaCreate.Data && w.PacienteId == dietaCreate.PacienteId);
            return dietaGet;
        }

        public DietaGetDto UpdateDieta(DietaUpdateDto dietaUpdate, int id)
        {
            DietaModel dietaModel = _dietaRepository.GetById(id);
            dietaModel = _mapper.Map(dietaUpdate, dietaModel);
            dietaModel.Tipo = Enum.GetName(typeof(ETipoDieta), dietaUpdate.Tipo.GetHashCode());
            _dietaRepository.Update(dietaModel);
            DietaGetDto dietaGet = _mapper.Map<DietaGetDto>(dietaModel);
            return dietaGet;
        }

        public bool DeleteDieta(int id)
        {
            bool remocao = _dietaRepository.Delete(id);
            if (remocao)
            {
                return true;
            }
            return false;
        }

    }
}