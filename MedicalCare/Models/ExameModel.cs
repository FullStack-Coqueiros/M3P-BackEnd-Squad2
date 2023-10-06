using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExameModel
{
    [Table("Exames")]
    public class ExameModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8)]
        [Column(TypeName = "VARCHAR")]
        public string NomeDoExame { get; set; }

        [Required]
        public DateTime DataDoExame { get; set; } = DateTime.Now;

        [Required]
        public DateTime HorarioDoExame { get; set; } = DateTime.Now;

        [Required]
        [StringLength(32, MinimumLength = 4)]
        [Column(TypeName = "VARCHAR")]
        public string TipoDoExame { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4)]
        [Column(TypeName = "VARCHAR")]
        public string Laboratorio { get; set; }

        public string UrlDoDocumento { get; set; }

        [Required]
        [StringLength(1024, MinimumLength = 16)]
        [Column(TypeName = "VARCHAR")]
        public string Resultados { get; set; }

        [Required]
        public bool StatusDoSistema { get; set; }

        [Required]
        [DisplayName("Id do Paciente")]
        public int PacienteId { get; set; }

        [Required]
        [DisplayName("Id do Médico/Enfermeiro")]
        public int UsuarioId { get; set; }
    }
}