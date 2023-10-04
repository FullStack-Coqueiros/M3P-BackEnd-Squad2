namespace MedicalCare.Models
{
    public class PacienteModel : PessoaModel
    {
        public DateTime DataDeNascimento { get; set; }
        public string Rg { get; set; }
        public string EstadoCivil { get; set; }
        public string Naturalidade { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public List<string> Alergias { get; set; }
        public List<string> CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroDoConvenio { get; set; }
        public DateTime ValidadeDoConvenio { get; set; }

    }
}
