
using MedicalCare.Models;
using MedicalCare.Interfaces;  

public class ExameService
{
    private readonly IExameRepository _exameRepository;  

    public ExameService(IExameRepository exameRepository)
    {
        _exameRepository = exameRepository;
    }

    public ExameModel CreateExame(ExameModel exame)
    {
        //  lógica de validação se necessário
        return _exameRepository.Create(exame);
    }

    public ExameModel UpdateExame(ExameModel exame)
    {
        //  lógica de validação se necessário
        return _exameRepository.Update(exame);
    }

    public ExameModel GetExameById(int id)
    {
        return _exameRepository.GetById(id);
    }

    public IEnumerable<ExameModel> GetAllExames()
    {
        return _exameRepository.GetAll();
    }

    public bool DeleteExame(int id)
    {
        return _exameRepository.Delete(id);
    }
}
