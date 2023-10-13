using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IPacienteService
    {
        PacienteGetDto CreatePaciente(PacienteCreateDto paciente);
        bool DeletePaciente(int id);
        IEnumerable<PacienteGetDto> GetAllPacientes();
        PacienteGetDto GetById(int id);
        PacienteGetDto UpdatePaciente(PacienteUpdateDto paciente);
    }
}