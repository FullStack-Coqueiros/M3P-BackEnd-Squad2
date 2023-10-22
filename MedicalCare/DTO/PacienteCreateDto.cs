using MedicalCare.Enums;
using MedicalCare.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class PacienteCreateDto
    {
        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Deve possuir entre 8 e 64 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required]
        public Egenero Genero { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 caracteres.")]
        public string Cpf { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Deve conter no máximo 20 caracteres.")]
        public string Rg { get; set; }

        [Required]
        public EestadoCivil EstadoCivil { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "Deve possuir entre 11 e 13 carcteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required, StringLength(64, MinimumLength = 8, ErrorMessage = "Deve conter entre 8 e 64 caracteres.")]
        public string Naturalidade { get; set; }

        [Required, StringLength(11, MinimumLength = 11, ErrorMessage = "Deve conter 11 caracteres.")]
        public string ContatoDeEmergencia { get; set; }

        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroDoConvenio { get; set; }
        public DateTime ValidadeDoConvenio { get; set; }

        [Required]
        public EnderecoCreateDto Endereco { get; set; }
        public bool StatusDoSistema { get; set; }
    }
}
