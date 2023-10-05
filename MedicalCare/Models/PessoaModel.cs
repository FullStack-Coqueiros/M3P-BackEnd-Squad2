using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Deve possuir entre 8 e 64 caracteres.")]
        [Column ("nome_completo")]
        public string NomeCompleto { get; set; }

        [Required]
        public  Egenero Genero{ get; set; } 

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 caracteres.")]
        public string Cpf { get; set; }

        [Required (ErrorMessage = "Email é obrigatório")]  
        public string Email { get; set; }

        [Column("Status do Sistema")]
        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool StatusNoSistema { get; set; }
    }
}
