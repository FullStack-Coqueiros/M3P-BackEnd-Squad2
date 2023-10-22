using MedicalCare.Models;
using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IConsultaService
    {
        ConsultaGetDto CreateConsulta(ConsultaCreateDTO consulta);
        ConsultaGetDto UpdateConsulta(ConsultaUpdateDTO consulta);
        ConsultaGetDto GetById(int id);
        IEnumerable<ConsultaGetDto> GetAllConsultas();
        bool DeleteConsulta(int id);
        IEnumerable<ConsultaGetDto> GetConsultasByPaciente(int consultaId, bool isSomeFlagSet);
    }
}
