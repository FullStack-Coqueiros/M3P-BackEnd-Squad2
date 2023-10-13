using MedicalCare.Enums;

namespace MedicalCare.DTO
{
    public class UsuarioUpdateDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public Egenero Genero { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public ETipo Tipo { get; set; }
    }
}