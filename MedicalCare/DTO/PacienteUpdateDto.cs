using MedicalCare.Enums;
using MedicalCare.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class PacienteUpdateDto
    {
        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Deve possuir entre 8 e 64 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required]
        public Egenero Genero { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        public EestadoCivil EstadoCivil { get; set; }

        [Required]
        [StringLength(13, MinimumLength =11, ErrorMessage ="Deve possuir entre 11 e 13 carcteres.")]
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
        public EnderecoUpdateDto Endereco { get; set; }

        [Required]
        public bool StatusDoSistema { get; set; }
    }
}

