using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Services
{
    public class MedicamentoService : IMedicamentoService

    {
        private readonly IRepository<MedicamentoModel> _medicamentoRepository;
        private readonly IMapper _mapper;

        public MedicamentoService(IMapper mapper, IRepository<MedicamentoModel> medicamentoRepository)
        {
            _mapper = mapper;
            _medicamentoRepository = medicamentoRepository;
        }

        public IEnumerable<MedicamentoGetDTO> GetAllMedicamentos()
        {
            IEnumerable<MedicamentoModel> medicamentos = _medicamentoRepository.GetAll();
            IEnumerable<MedicamentoGetDTO> medicamentoGet = _mapper.Map<IEnumerable<MedicamentoGetDTO>>(medicamentos);
            return medicamentoGet;
        }

        public MedicamentoGetDTO GetById(int id)
        {
            MedicamentoModel medicamento = _medicamentoRepository.GetById(id);
            MedicamentoGetDTO medicamentoGetId = _mapper.Map<MedicamentoGetDTO>(medicamento);
            return medicamentoGetId;
        }

        public MedicamentoGetDTO CreateMedicamento(MedicamentoCreateDTO medicamento)
        {
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            _medicamentoRepository.Create(medicamentoModel);
            MedicamentoGetDTO medicamentoGet = _mapper.Map<MedicamentoGetDTO>(medicamento);
            return medicamentoGet;
        }

        public MedicamentoGetDTO UpdateMedicamento(MedicamentoUpdateDTO medicamento)
        {
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            _medicamentoRepository.Update(medicamentoModel);
            MedicamentoGetDTO medicamentoGet = _mapper.Map<MedicamentoGetDTO>(medicamento);
            return medicamentoGet;
        }

        public bool DeleteMedicamento(int id)
        {
            bool remocaoMedicamento = _medicamentoRepository.Delete(id);
            if (remocaoMedicamento)
            {
                return true;
            }
            return false;
        }
    }



}
