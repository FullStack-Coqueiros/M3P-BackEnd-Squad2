using MedicalCare.Enums;

namespace MedicalCare.DTO
{
    public class PacienteUpdateDto
    {
        public string Email { get; set; }
        public bool StatusNoSistema { get; set; }
        public EestadoCivil EstadoCivil { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public List<string> Alergias { get; set; }
        public List<string> CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroDoConvenio { get; set; }
        public DateTime ValidadeDoConvenio { get; set; }
    }
}

