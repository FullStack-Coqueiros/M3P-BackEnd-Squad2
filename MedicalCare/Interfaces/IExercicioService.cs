using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface IExercicioService
    {
        ExercicioGetDto CreateExercicio(ExercicioCreateDto exercicio);
        bool DeleteExercicio(int id);
        IEnumerable<ExercicioGetDto> GetAllExercicios();
        ExercicioGetDto GetById(int id);
        ExercicioGetDto UpdateExercicio(ExercicioUpdateDto exercicio);

        IEnumerable<ExercicioGetDto> GetExerciciosByPaciente(int pacienteId,bool isSomeOtherFlagSet);
    }
}