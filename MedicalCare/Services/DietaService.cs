
using AutoMapper;
using MedicalCare.DTO;
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

        public DietaGetDto CreateDieta(DietaCreateDto dieta)
        {
            DietaModel dietaModel = _mapper.Map<DietaModel>(dieta);
            _dietaRepository.Create(dietaModel);
            DietaGetDto dietaGet = _mapper.Map<DietaGetDto>(dieta);
            return dietaGet;
        }

        public DietaGetDto UpdateDieta(DietaUpdateDto dieta)
        {
            DietaModel dietaModel = _mapper.Map<DietaModel>(dieta);
            _dietaRepository.Update(dietaModel);
            DietaGetDto dietaGet = _mapper.Map<DietaGetDto>(dieta);
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