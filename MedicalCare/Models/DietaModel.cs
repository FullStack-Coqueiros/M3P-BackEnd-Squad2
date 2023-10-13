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

        [Required(ErrorMessage = "O Nome da Dieta é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Nome da Dieta deve ter entre 5 e 100 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public string NomeDaDieta { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Data é obrigatória.")]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Horário é obrigatório.")]
        public DateTime Horario { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Tipo da Dieta é obrigatório.")]
        [StringLength(32, ErrorMessage = "O Tipo da Dieta deve ter no máximo 32 caracteres.")]
        [Column(TypeName = "VARCHAR")]
        public ETipoDieta Tipo { get; set; }

        public string DescricaoDaDietaExecutada { get; set; }

        [Required(ErrorMessage = "O Status do Sistema é obrigatório.")]
        public bool StatusDoSistema { get; set; } = true;

        [Required(ErrorMessage = "O Id do Paciente é obrigatório.")]
        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        [Required(ErrorMessage = "O Id do Usuário é obrigatório.")]
        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
