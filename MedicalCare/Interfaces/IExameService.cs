using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IExameService
    {
        ExameGetDto CreateExame(ExameCreateDto exame);
        ExameGetDto UpdateExame(ExameUpdateDto exame);
        ExameGetDto GetById(int id);
        IEnumerable<ExameGetDto> GetAllExames();
        bool DeleteExame(int id);

        IEnumerable<ExameGetDto> GetExamesByPaciente(int pacienteId, bool isSomeFlagSet);


    }
}
