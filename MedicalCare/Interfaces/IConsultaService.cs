using MedicalCare.Models;
using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IConsultaService
    {
        ConsultaGetDto CreateConsulta(ConsultaCreateDTO consulta);
        bool DeleteConsulta(int id);
        IEnumerable<ConsultaGetDto> GetAllConsultas();
        ConsultaGetDto GetById(int id);
        ConsultaGetDto UpdateConsulta(ConsultaUpdateDTO consulta, int id);
    }
}
