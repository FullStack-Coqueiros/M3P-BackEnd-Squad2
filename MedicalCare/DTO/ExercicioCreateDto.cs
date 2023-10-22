using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class ExercicioCreateDto
    {
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "Deve conter entre 5 e 100 caracteres.")]
        public string NomeDaSerieDeExercicios { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string Horario { get; set; }

        [Required]
        public EtipoExercicio Tipo { get; set; }

        [Required, DataType("DECIMAL(3,2)", ErrorMessage = "Deve conter no minimo dois numeros após a vírgula.")]
        public int QuantidadePorSemana { get; set; }

        [Required, StringLength(1000, MinimumLength = 10, ErrorMessage = "Deve conter entre 10 e 1000 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        public bool StatusDoSistema { get; set; }

        [Required]
        public int PacienteId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
