using MedicalCare.Enums;

namespace MedicalCare.DTO
{
    public class ExercicioUpdateDto
    {
         public string NomeDaSerieDeExercicios { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }
        public EtipoExercicio Tipo { get; set; }
        public int QuantidadePorSemana { get; set; }
        public string Descricao { get; set; }
        public bool StatusDoSistema { get; set; }
        public int UsuarioId { get; set; }
        public int PacienteId { get; set; }
    }
}
