using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class ExercicioGetDto
    {
        public int Identificador { get; set; }
        public string Nome_Da_Serie_De_Exercicios { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public EtipoExercicio Tipo { get; set; }
        public int Quantidade_Por_Semana { get; set; }
        public string Descricao { get; set; }
        public bool Status_no_sistema { get; set; }
        public int Id_do_usuario { get; set; }
        public int Id_do_paciente { get; set; }
    }
}
