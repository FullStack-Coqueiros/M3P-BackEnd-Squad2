using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class ExercicioGetDto
    {
        public int Id { get; set; }
        public int PacienteId {get; set;}
        public string NomeDaSerieDeExercicios { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }
        public EtipoExercicio Tipo { get; set; }
        public int Quantidade_Por_Semana { get; set; }
        public string Descricao { get; set; }
        public bool StatusDoSistema { get; set; }
        public int Id_do_usuario { get; set; }
        public int Id_do_paciente { get; set; }
    }
}
