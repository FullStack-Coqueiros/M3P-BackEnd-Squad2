namespace MedicalCare.DTO
{
    public class EnderecoCreateDto
    {
        public string cep { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string bairro { get; set; }
        public string PontoDeReferencia { get; set; }
        public int PacienteId { get; set; }

    }
}
