using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("ConsultaModel")]

    public class ConsultaModel
    {
        [Key]
        public int Id { get; set; }

        public string MotivoDaConsulta { get; set; }

        public DateTime DataDaConsulta { get; set; } = DateTime.Now;

        public DateTime HorarioDaConsulta { get; set; } = DateTime.Now;

        public string DescricaoDoProblema { get; set; }

        public string MedicacaoReceitada { get; set; }

        public string DosagemEPrecaucoes { get; set; }

        public bool StatusDoSistema { get; set; }

        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
