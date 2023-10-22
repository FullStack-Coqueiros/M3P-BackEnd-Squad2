using System.ComponentModel.DataAnnotations;

namespace MedicalCare.DTO
{
    public class ConsultaCreateDTO
    {
        [Required(ErrorMessage = "Favor inserir o motivo da consulta!")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Motivo da consulta deve ter entre 8 e 64 caracteres.")]
        public string MotivoDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir a data da consulta!")]
        public DateTime DataDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir o horário da consulta!")]
        public DateTime HorarioDaConsulta { get; set; }

        [Required(ErrorMessage = "Favor inserir a descrição do problema!")]
        [StringLength(1024, MinimumLength = 16, ErrorMessage = "Descrição do problema deve ter entre 16 e 1024 caracteres.")]
        public string DescricaoDoProblema { get; set; }

        public string MedicacaoReceitada { get; set; }

        [Required(ErrorMessage = "Favor inserir a dosagem e preocupações!")]
        [StringLength(256, MinimumLength = 16, ErrorMessage = "Dosagem e Precauções deve ter entre 16 e 256 caracteres.")]
        public string DosagemEPrecaucoes { get; set; }

        [Required(ErrorMessage = "Favor inserir o status do sistema!")]
        public bool StatusDoSistema { get; set; }

        [Required(ErrorMessage = "O Id do Paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O Id do Usuário é obrigatório.")]
        public int UsuarioId { get; set; }
    }
}
