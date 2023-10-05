using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    public class PacienteModel : PessoaModel
    {
        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Deve conter no máximo 20 caracteres.")]
        public string Rg { get; set; }

        [Required]
        public string EstadoCivil { get; set; } // mudar para enum

        [Required, StringLength(64, MinimumLength = 8, ErrorMessage = "Deve conter entre 8 e 64 caracteres.")]
        public string Naturalidade { get; set; }

        [Required, StringLength(10, MinimumLength = 10, ErrorMessage = "Deve conter 10 caracteres.")]
        public string ContatoDeEmergencia { get; set; }

        public List<string> Alergias { get; set; }

        [Column("Cuidados")]
        public List<string> CuidadosEspecificos { get; set; }


        public string Convenio { get; set; }

        public string NumeroDoConvenio { get; set; }

        public DateTime ValidadeDoConvenio { get; set; }

    }
}
