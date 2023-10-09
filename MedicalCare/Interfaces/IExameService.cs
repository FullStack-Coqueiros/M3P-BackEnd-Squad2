
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IExameService
    {
        ExameModel Create(ExameModel exame);
        ExameModel Update(ExameModel exame);
        ExameModel GetById(int id);
        IEnumerable<ExameModel> GetAllExames();
        bool Delete(int id);

    }
}
