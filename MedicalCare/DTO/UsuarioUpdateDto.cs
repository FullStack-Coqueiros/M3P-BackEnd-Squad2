using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class UsuarioUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Deve possuir entre 8 e 64 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required]
        [StringLength(32)]
        public Egenero Genero { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone deve estar no formato (99) 99999-9999")]
        public string Telefone { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Deve conter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório.")]
        public ETipo Tipo { get; set; }
    }
}