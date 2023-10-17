using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalCare.DTO;


namespace MedicalCare.Interfaces
{
    public interface IMedicamentoService
    {
        MedicamentoGetDTO CreateMedicamento(MedicamentoCreateDTO medicamento);
        MedicamentoGetDTO UpdateMedicamento(MedicamentoUpdateDTO medicamento, int id);
        MedicamentoGetDTO GetById (int id);
        IEnumerable<MedicamentoGetDTO> GetAllMedicamentos();
        bool DeleteMedicamento(int id);
        


    }
}