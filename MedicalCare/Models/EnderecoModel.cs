using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("EnderecoModel")]
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(8, MinimumLength = 8)]
        public string Cep { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string Cidade { get; set; }

        [Required, StringLength(20, MinimumLength = 2)]
        public string Estado { get; set; }

        [Required, StringLength(50, MinimumLength = 8)]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required, StringLength(40, MinimumLength = 5)]
        public string Complemento { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Bairro { get; set; }

        [Required, StringLength(60, MinimumLength = 6)]
        public string PontoDeReferencia { get; set; }

    }
}
