using MedicalCare.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("ExercicioModel")]
    public class ExercicioModel
    {
        [Key]
        public int Id { get; set; }

        public string NomeDaSerieDeExercicios { get; set; }

        public DateTime Data { get; set; }

        public DateTime Horario { get; set; }

        public string Tipo { get; set; } 

        public int QuantidadePorSemana { get; set; }

        public string Descricao { get; set; }

        public bool StatusDoSistema { get; set; }

        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
