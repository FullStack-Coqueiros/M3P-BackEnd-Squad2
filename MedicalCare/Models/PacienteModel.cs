using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("PacienteModel")]
    public class PacienteModel : PessoaModel
    {
        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Deve conter no máximo 20 caracteres.")]
        public string Rg { get; set; }

        [Required]
        public EestadoCivil EstadoCivil { get; set; } 

        [Required, StringLength(64, MinimumLength = 8, ErrorMessage = "Deve conter entre 8 e 64 caracteres.")]
        public string Naturalidade { get; set; }

        [Required, StringLength(11, MinimumLength = 11, ErrorMessage = "Deve conter 11 caracteres.")]
        public string ContatoDeEmergencia { get; set; }

        public string Alergias { get; set; }

        [Column("Cuidados")]
        public string CuidadosEspecificos { get; set; }


        public string Convenio { get; set; }

        public string NumeroDoConvenio { get; set; }

        public DateTime ValidadeDoConvenio { get; set; }
        //public int EnderecoId { get; set; }
        //public EnderecoModel Endereco { get; set; }

    }
}
