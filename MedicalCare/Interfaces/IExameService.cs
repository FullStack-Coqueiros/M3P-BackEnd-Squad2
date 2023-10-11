
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IExameService
    {
        ExameGetDto CreateExame(ExameCreateDto exame);
        ExameGetDto UpdateExame(ExameUpdateDto exame);
        ExameGetDto GetById(int id);
        IEnumerable<ExameGetDto> GetAllExames();
        bool DeleteExame(int id);

    }
}
