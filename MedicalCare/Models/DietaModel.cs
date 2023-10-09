using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCare.Enums;

namespace MedicalCare.Models


{
    [Table("Dietas")]
    public class DietaModel

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [Column(TypeName = "VARCHAR")]
        public string NomeDaDieta { get; set; }


        public string Descricao { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required]
        public DateTime Horario { get; set; } = DateTime.Now;

        [Required]
        [StringLength(32)]
        [Column(TypeName = "VARCHAR")]
        public ETipoDieta Tipo { get; set; }


        public string DescricaoDaDietaExecutada { get; set; }

        [Required]
        public bool StatusDoSistema { get; set; }

        [ForeignKey("PacienteModel")]
        [Required]
        [DisplayName("Id do Paciente")]
        public PacienteModel Paciente { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }

    }



}
