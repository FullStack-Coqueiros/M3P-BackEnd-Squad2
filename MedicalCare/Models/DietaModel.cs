
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalCare.Enums;

namespace MedicalCare.Models
{
    [Table("DietaModel")]
    public class DietaModel
    {
        [Key]
        public int Id { get; set; }

        public string NomeDaDieta { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public DateTime Horario { get; set; } = DateTime.Now;

        public string Tipo { get; set; }

        public string DescricaoDaDietaExecutada { get; set; }

        public bool StatusDoSistema { get; set; } = true;

        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
