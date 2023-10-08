
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IExameRepository
    {
        ExameModel Create(ExameModel exame);
        ExameModel Update(ExameModel exame);
        ExameModel GetById(int id);
        IEnumerable<ExameModel> GetAll();
        bool Delete(int id);

    }
}
