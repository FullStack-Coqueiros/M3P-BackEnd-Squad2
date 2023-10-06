namespace MedicalCare.DTO
{
    public class ConsultaCreateDTO
    {
        public string MotivoDaConsulta { get; set; }
        public DateTime DataDaConsulta { get; set; }
        public DateTime HorarioDaConsulta { get; set; }
        public string DescricaoDoProblema { get; set; }
        public string MedicacaoReceitada { get; set; }
        public string DosagemEPrecaucoes { get; set; }
        public bool StatusDoSistema { get; set; }
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
    }
}
