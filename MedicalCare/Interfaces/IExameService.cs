using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IExameService
    {
        ExameGetDto CreateExame(ExameCreateDto exame);
        ExameGetDto UpdateExame(ExameUpdateDto exame, int id);
        ExameGetDto GetById(int id);
        IEnumerable<ExameGetDto> GetAllExames();
        bool DeleteExame(int id);
    }
}
