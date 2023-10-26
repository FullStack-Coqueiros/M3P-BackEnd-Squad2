using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("ExameModel")]
    public class ExameModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Exame � obrigat�rio.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O Nome do Exame deve ter entre 8 e 64 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string NomeDoExame { get; set; }

        [Required(ErrorMessage = "A Data do Exame � obrigat�ria.")]
        [Column(TypeName = "Date")]
        public DateTime DataDoExame { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Hor�rio do Exame � obrigat�rio.")]
        public TimeSpan HorarioDoExame { get; set; } = DateTime.Now.TimeOfDay;
        [Required(ErrorMessage = "O Tipo do Exame � obrigat�rio.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O Tipo do Exame deve ter entre 4 e 32 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string TipoDoExame { get; set; }

        [Required(ErrorMessage = "O Laborat�rio � obrigat�rio.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O Laborat�rio deve ter entre 4 e 32 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string Laboratorio { get; set; }

        [Url(ErrorMessage = "A URL do Documento n�o � v�lida.")]
        public string UrlDoDocumento { get; set; }

        [Required(ErrorMessage = "Os Resultados s�o obrigat�rios.")]
        [StringLength(1024, MinimumLength = 16, ErrorMessage = "Os Resultados devem ter entre 16 e 1024 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string Resultados { get; set; }

        [Required(ErrorMessage = "O Status do Sistema � obrigat�rio.")]
        public bool StatusDoSistema { get; set; }

        [Required(ErrorMessage = "O Id do Paciente � obrigat�rio.")]
        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        [Required(ErrorMessage = "O Id do Usu�rio � obrigat�rio.")]
        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
