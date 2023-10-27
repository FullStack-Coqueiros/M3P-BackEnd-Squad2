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

        public string NomeDoExame { get; set; }

        public DateTime DataDoExame { get; set; } = DateTime.Now;

        public DateTime HorarioDoExame { get; set; } = DateTime.Now;
        
        public string TipoDoExame { get; set; }

        public string Laboratorio { get; set; }

        public string UrlDoDocumento { get; set; }

        
        public string Resultados { get; set; }

        public bool StatusDoSistema { get; set; }

        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
