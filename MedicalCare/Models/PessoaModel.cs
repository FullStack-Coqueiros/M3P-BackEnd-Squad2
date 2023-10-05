namespace MedicalCare.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public bool StatusNoSistema { get; set; }
    }
}
