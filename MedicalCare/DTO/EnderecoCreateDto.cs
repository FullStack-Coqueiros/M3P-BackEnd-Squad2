using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class EnderecoCreateDto
    {
        [Required, StringLength(8, MinimumLength = 8)]
        public string cep { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string localidade { get; set; }

        [Required, StringLength(20, MinimumLength = 2)]
        public string uf { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required, StringLength(40, MinimumLength = 3)]
        public string Complemento { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string bairro { get; set; }

        [Required, StringLength(60, MinimumLength = 6)]
        public string PontoDeReferencia { get; set; }

        public int PacienteId { get; set; }

    }
}
