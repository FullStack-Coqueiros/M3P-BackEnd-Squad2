using MedicalCare.Enums;

namespace MedicalCare.DTO
{
    public class DietaUpdateDto
    {
        public int Id { get; set; }
        public string NomeDaDieta { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public ETipoDieta Tipo { get; set; }
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
    }
}
