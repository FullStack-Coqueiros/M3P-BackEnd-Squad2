using MedicalCare.Enums;
using MedicalCare.Models;

namespace MedicalCare.DTO
{
    public class PacienteGetDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public string Naturalidade { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroDoConvenio { get; set; }
        public DateTime ValidadeDoConvenio { get; set; }
        public EnderecoGetDto Endereco { get; set; }
        public bool StatusDoSistema { get; set; }
    }
}
