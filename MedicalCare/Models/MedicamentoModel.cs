using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MedicalCare.Models
{
    [Table("MedicamentoModel")]
    public class MedicamentoModel
    {
        [Key]
        public int Id { get; set; } 

        [Column ("Nome do Medicamento")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 100 caracteres.")]
        [Required(ErrorMessage = "O nome do medicamento é obrigatório")]
        public string NomeDoMedicamento {get; set;}

        [Column ("Data")]
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data {get; set;}

        [Column ("Tipo")] 
        [Required(ErrorMessage = "O tipo de medicamento é obrigatório")]
        public string Tipo {get;set;}

        [Column ("Quantidade")] 
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        public int Quantidade {get; set;}

        [Column ("Unidade")]
        [Required(ErrorMessage = "A unidade é obrigatória")]
        public string Unidade {get; set;}

        [Column ("Observações")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Observações devem ter entre 10 e 1000 caracteres.")]
        [Required(ErrorMessage = "As observações são obrigatórias")]  
        public string Observacoes {get; set;}

        [Column ("Status do Sistema")]
        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool StatusDoSistema {get; set;}

        [Required]
        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}