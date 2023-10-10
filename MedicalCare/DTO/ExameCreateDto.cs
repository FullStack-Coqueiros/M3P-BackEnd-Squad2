namespace MedicalCare.DTO
{
    public class ExameCreateDto
    {
        public string NomeDoExame { get; set; }
        public DateTime DataDoExame { get; set; }
        public DateTime HorarioDoExame { get; set; }
        public string TipoDoExame { get; set; }
        public string Laboratorio { get; set; }
        public string UrlDoDocumento { get; set; }
        public string Resultados { get; set; }
        public bool StatusDoSistema { get; set; }
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }

    }
}
