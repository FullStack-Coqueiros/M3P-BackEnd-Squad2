using MedicalCare.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public  string Genero{ get; set; } 

        public string Cpf { get; set; }

        public string Email { get; set; }

        public bool StatusDoSistema { get; set; }
    }
}
