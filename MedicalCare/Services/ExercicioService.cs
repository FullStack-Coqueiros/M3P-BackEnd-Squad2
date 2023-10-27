using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Services
{
    public class ExercicioService : IExercicioService
    {
        private readonly IRepository<ExercicioModel> _exercicioRepository;
        private readonly IMapper _mapper;

        public ExercicioService(IMapper mapper, IRepository<ExercicioModel> exercicioRepository)
        {
            _mapper = mapper;
            _exercicioRepository = exercicioRepository;
        }


        public IEnumerable<ExercicioGetDto> GetAllExercicios()
        {
            IEnumerable<ExercicioModel> exercicios = _exercicioRepository.GetAll();
            IEnumerable<ExercicioGetDto> exercicioGet = _mapper.Map<IEnumerable<ExercicioGetDto>>(exercicios);
            return exercicioGet;
        }

        public ExercicioGetDto GetById(int id)
        {
            ExercicioModel exercicio = _exercicioRepository.GetById(id);
            ExercicioGetDto exercicioGetId = _mapper.Map<ExercicioGetDto>(exercicio);
            return exercicioGetId;
        }

        public ExercicioGetDto CreateExercicio(ExercicioCreateDto exercicio)
        {
            ExercicioModel exercicioModel = _mapper.Map<ExercicioModel>(exercicio);
            _exercicioRepository.Create(exercicioModel);
            ExercicioGetDto exercicioGet = _mapper.Map<ExercicioGetDto>(exercicioModel);
            return exercicioGet;
        }

        public ExercicioGetDto UpdateExercicio(ExercicioUpdateDto exercicio, int id)
        {
            ExercicioModel exercicioModel = _exercicioRepository.GetById(id);
            exercicioModel = _mapper.Map(exercicio, exercicioModel);
            _exercicioRepository.Update(exercicioModel);
            ExercicioGetDto exercicioGet = _mapper.Map<ExercicioGetDto>(exercicioModel);
            return exercicioGet;
        }

        public bool DeleteExercicio(int id)
        {
            bool remocao = _exercicioRepository.Delete(id);
            if (remocao)
            {
                return true;
            }
            return false;
        }

    }
}