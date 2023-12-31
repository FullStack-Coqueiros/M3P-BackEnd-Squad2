using MedicalCare.Enums;

namespace MedicalCare.DTO
{
    public class UsuarioGetDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public bool StatusDoSistema { get; set; }
    }
}