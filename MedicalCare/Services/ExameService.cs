using MedicalCare.Models;

namespace MedicalCare.Services
{

    public class ExameService
    {
        private readonly ExameRepository _exameRepository;

        public ExameService(ExameRepository exameRepository)
        {
            _exameRepository = exameRepository;
        }

        public ExameModel CreateExame(ExameModel exame)
        {
            // Adicionar lógica de validação se necessário
            return _exameRepository.Create(exame);
        }

        public ExameModel UpdateExame(ExameModel exame)
        {
            // Adicionar lógica de validação se necessário
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
}
