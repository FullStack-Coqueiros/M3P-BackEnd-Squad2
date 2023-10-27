
using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class DietaCreateDto
    {

        [Required(ErrorMessage = "O Nome da Dieta é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Nome da Dieta deve ter entre 5 e 100 caracteres.")]
        public string NomeDaDieta { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Horário é obrigatório.")]
        public DateTime Horario { get; set; }

        [Required(ErrorMessage = "O Tipo da Dieta é obrigatório.")]
        public ETipoDieta Tipo { get; set; }

        public string DescricaoDaDietaExecutada { get; set; }

        [Required(ErrorMessage = "O Id do Paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O Id do Usuário é obrigatório.")]
        public int UsuarioId { get; set; }

    }
}
