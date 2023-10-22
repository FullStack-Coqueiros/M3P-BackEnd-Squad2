using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class EnderecoCreateDto
    {
        [Required, StringLength(8, MinimumLength = 8, ErrorMessage = "Insira 8 caracteres.")]
        public string cep { get; set; }

        [Required, StringLength(30, MinimumLength = 3, ErrorMessage ="Insira entre 3 e 30 caracteres.")]
        public string localidade { get; set; }

        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "Insira entre 2 e 20 caracteres.")]
        public string uf { get; set; }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 50 caracteres.")]
        public string logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required, StringLength(40, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 40 caracteres.")]
        public string Complemento { get; set; }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "Insira entre 3 e 50 caracteres.")]
        public string bairro { get; set; }

        [Required, StringLength(60, MinimumLength = 6, ErrorMessage = "Insira entre 6 e 60 caracteres.")]
        public string PontoDeReferencia { get; set; }

        public int PacienteId { get; set; }

    }
}
