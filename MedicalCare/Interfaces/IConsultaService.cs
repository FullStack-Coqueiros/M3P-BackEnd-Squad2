using MedicalCare.Models;
using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IConsultaService
    {
        IEnumerable<ConsultaGetDto> GetAllConsultas();
        ConsultaGetDto CreateConsulta(ConsultaCreateDTO consulta);
        ConsultaGetDto GetById(int id);
        ConsultaGetDto UpdateConsulta(ConsultaUpdateDTO consulta);
        bool DeleteConsulta(int id);
    }
}
