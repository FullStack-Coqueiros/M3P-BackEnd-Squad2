using System.ComponentModel.DataAnnotations;

namespace MedicalCare.Models
{
    [Table("Consultas")]

    public class ConsultaModel
    {
        [Key]
        public int ConsultaId { get; set; }

        [Required(ErrorMessage = "Favor inserir o motivo da consulta!"), MinLength(8),MaxLength(64)]
        public string MotivoDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir a data da consulta!")]
        public DateTime DataDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir o horário da consulta!")]
        public DateTime HorarioDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir a descrição do problema!"), MinLength(16), MaxLength(1024)]
        public string DescricaoDoProblema { get; set; }

        public string MedicacaoReceitada { get; set; }

        [Required(ErrorMessage = "Favor inserir a dosagem e preocupações!"), MinLength(16), MaxLength(256)]
        public string DosagemEPrecaucoes { get; set; }

        [Required(ErrorMessage = "Favor inserir o status do sistema!")]
        public bool StatusDoSistema { get; set; }

        public int PacienteId { get; set; }

        public int UsuarioId { get; set; }
    }
}
