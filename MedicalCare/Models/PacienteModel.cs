using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("PacienteModel")]
    public class PacienteModel : PessoaModel
    {
        [Column(TypeName = "Date")]
        public DateTime DataDeNascimento { get; set; }

        public string Rg { get; set; }

        public string EstadoCivil { get; set; } 

        public string Telefone { get; set; }

        public string Naturalidade { get; set; }

        public string ContatoDeEmergencia { get; set; }

        public string Alergias { get; set; }

        public string CuidadosEspecificos { get; set; }

        public string Convenio { get; set; }

        public string NumeroDoConvenio { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ValidadeDoConvenio { get; set; }
        public EnderecoModel Endereco { get; set; }
        public ICollection<ConsultaModel> Consultas { get; set; }
        public ICollection<DietaModel> Dietas { get; set; }
        public ICollection<ExameModel> Exames { get; set; }
        public ICollection<ExercicioModel> Exercicios { get; set; }
        public ICollection<MedicamentoModel> Medicamentos { get; set; }


    }
}
