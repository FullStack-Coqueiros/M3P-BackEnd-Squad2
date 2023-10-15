using MedicalCare.Enums;
using MedicalCare.Models;

namespace MedicalCare.DTO
{
    public class PacienteUpdateDto
    {
        public string NomeCompleto { get; set; }
        public  string Cpf { get; set; }
        public string Rg { get; set; }
        public Egenero Genero { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public EestadoCivil EstadoCivil { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Naturalidade { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public List<string> Alergias { get; set; }
        public List<string> CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroDoConvenio { get; set; }
        public DateTime ValidadeDoConvenio { get; set; }
        public EnderecoModel Endereco { get; set; }
        public bool StatusDoSistema { get; set; }
    }
}

