using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IRepository<PacienteModel> _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IMapper mapper, IRepository<PacienteModel> pacienteRepository)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
        }



        public IEnumerable<PacienteGetDto> GetAllPacientes()
        {
            IEnumerable<PacienteModel> pacientes = _pacienteRepository.GetAll();
            IEnumerable<PacienteGetDto> pacienteGet = _mapper.Map<IEnumerable<PacienteGetDto>>(pacientes);
            return pacienteGet;
        }

        public PacienteGetDto GetById(int id)
        {
            PacienteModel paciente = _pacienteRepository.GetById(id);
            PacienteGetDto pacienteGetId = _mapper.Map<PacienteGetDto>(paciente);
            return pacienteGetId;
        }

        public PacienteGetDto CreatePaciente(PacienteCreateDto paciente)
        {
            PacienteModel pacienteModel = _mapper.Map<PacienteModel>(paciente);
            _pacienteRepository.Create(pacienteModel);
            PacienteGetDto pacienteGet = _mapper.Map<PacienteGetDto>(paciente);
            return pacienteGet;
        }

        public PacienteGetDto UpdatePaciente(PacienteUpdateDto paciente)
        {
            PacienteModel pacienteModel = _mapper.Map<PacienteModel>(paciente);
            _pacienteRepository.Update(pacienteModel);
            PacienteGetDto pacienteGet = _mapper.Map<PacienteGetDto>(paciente);
            return pacienteGet;
        }

        public bool DeletePaciente(int id)
        {
            bool remocao = _pacienteRepository.Delete(id);
            if (remocao)
            {
                return true;
            }
            return false;
        }

    }
}