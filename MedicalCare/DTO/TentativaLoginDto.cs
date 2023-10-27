

namespace MedicalCare.DTO
{
    public class TentativaLoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Logado { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}