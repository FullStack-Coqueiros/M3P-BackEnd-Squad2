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
        //private readonly IRepository<EnderecoModel> _enderecoRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public PacienteService(IMapper mapper, IRepository<PacienteModel> pacienteRepository, IEnderecoService enderecoService)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
            //_enderecoRepository = enderecoRepository;
            _enderecoService = enderecoService;
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

        public PacienteGetDto CreatePaciente(PacienteCreateDto pacienteCreate)
        {
            PacienteModel pacienteModel = _mapper.Map<PacienteModel>(pacienteCreate);
            _pacienteRepository.Create(pacienteModel);
            PacienteModel pacienteModelComId = _pacienteRepository.GetAll()
                               .Where(a => a.Cpf == pacienteCreate.Cpf).FirstOrDefault();

            EnderecoCreateDto enderecoCreate = _mapper.Map<EnderecoCreateDto>(pacienteCreate.Endereco);
            enderecoCreate.PacienteId = pacienteModelComId.Id;
            _enderecoService.CreateEndereco(enderecoCreate); 

            EnderecoGetDto enderecoGet = _enderecoService.GetByRelationship(pacienteModel);
            
            PacienteGetDto pacienteGet = _mapper.Map<PacienteGetDto>(pacienteModelComId);
            pacienteGet.Endereco = enderecoGet;
            
            return pacienteGet;
        }

        public PacienteGetDto UpdatePaciente(PacienteUpdateDto pacienteUpdate, int id)
        {
            PacienteModel pacienteModel = _pacienteRepository.GetById(id);
            pacienteModel = _mapper.Map(pacienteUpdate, pacienteModel);
            Console.WriteLine(pacienteModel);
            _pacienteRepository.Update(pacienteModel);
            PacienteModel pacienteModelAtualizado = _pacienteRepository.GetById(id);
            PacienteGetDto pacienteGet = _mapper.Map<PacienteGetDto>(pacienteModelAtualizado);
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