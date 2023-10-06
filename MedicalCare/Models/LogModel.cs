using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("Logs")]
    public class LogModel
    {
        [Required(ErrorMessage = "Favor inserir a data do Log!")]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Favor inserir o domínio!")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Dominio deve ter entre 8 e 64 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string Dominio { get; set; }

        [Required(ErrorMessage = "Favor inserir a descrição!")]
        [StringLength(1024, MinimumLength = 8, ErrorMessage = "Descrição do problema deve ter entre 8 e 1024 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string Descricao { get; set; }
    }
}
