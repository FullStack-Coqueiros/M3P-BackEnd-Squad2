using MedicalCare.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("Exercicios")]
    public class ExercicioModel
    {
        //Creio que será uma relação n x n, visto que um tipo de exercicio pode estar presente em varios prontuarios,
        //e um paciente pode ter varios tipos de exercicios prescritos
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100,MinimumLength = 5, ErrorMessage = "Deve conter entre 5 e 100 caracteres.")]
        public string NomeDaSerieDeExercicios { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string Hora { get; set; }

        [Required]
        public EtipoExercicio Tipo { get; set; } 

        [Required, DataType("DECIMAL(3,2)", ErrorMessage = "Deve conter no minimo dois numeros após a vírgula.")]
        public int QuantidadePorSemana { get; set; }

        [Required, StringLength(1000, MinimumLength = 10, ErrorMessage = "Deve conter entre 10 e 1000 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        public bool StatusNoSistema { get; set; }

        [ForeignKey("PacienteModel")]
        [Required]
        [DisplayName("Id do Paciente")]
        public PacienteModel Paciente { get; set; }

        [ForeignKey("UsuarioModel")]
        [Required]
        [DisplayName("Id do Médico/Enfermeiro")]
        public UsuarioModel UsuarioId { get; set; }
    }
}
