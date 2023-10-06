using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("Consultas")]

    public class ConsultaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor inserir o motivo da consulta!")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Motivo da consulta deve ter entre 8 e 64 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string MotivoDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir a data da consulta!")]
        public DateTime DataDaConsulta { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Favor inserir o horário da consulta!")]
        public DateTime HorarioDaConsulta { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Favor inserir a descrição do problema!")]
        [StringLength(1024, MinimumLength = 16, ErrorMessage = "Descrição do problema deve ter entre 16 e 1024 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string DescricaoDoProblema { get; set; }

        public string MedicacaoReceitada { get; set; }

        [Required(ErrorMessage = "Favor inserir a dosagem e preocupações!")]
        [StringLength(256, MinimumLength = 16, ErrorMessage = "Dosagem e Precauções deve ter entre 16 e 256 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string DosagemEPrecaucoes { get; set; }

        [Required(ErrorMessage = "Favor inserir o status do sistema!")]
        public bool StatusDoSistema { get; set; }

        //[ForeignKey("Paciente")]
        [Required]
        [DisplayName("Id do Paciente")]
        public int PacienteId { get; set; }
        // public PacienteModel Paciente { get; set; }

        //[ForeignKey("Usuario")]
        [Required]
        [DisplayName("Id do Médico/Enfermeiro")]
        public int UsuarioId { get; set; }
        // public UsuarioModel Usuario { get; set; }
    }
}
