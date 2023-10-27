using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class ExercicioGetDto
    {
        public int Id { get; set; }

        public string NomeDaSerieDeExercicios { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public string Tipo { get; set; }
        public int Quantidade_Por_Semana { get; set; }
        public string Descricao { get; set; }
        public bool StatusDoSistema { get; set; }
        public int PacienteId {get; set;}
        public int UsuarioId { get; set; }
    }
}
