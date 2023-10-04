using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCare.Models
{
    [Table("Medicamentos")]
    public class MedicamentosModel
    {
        [Column ("Nome do Medicamento")]
        [Maxlenght(100), Minilenght(5)]
        [Required(ErrorMessage = "O nome do medicamento é obrigatório")]
        public string NomeDoMedicamento {get; set;}

        [Column ("Data")]
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime {get; set;}

        [Column ("Hora")]
         [Required(ErrorMessage = "A hora é obrigatória")]
        public DateTime.Now {get; set;}

        [Column ("Tipo")] 
        [Required(ErrorMessage = "O tipo de medicamento é obrigatório")]
        public string Tipo {get;set;}

        [Column ("Opções")]
        public enum Opcoes {get; set}

        [Column ("Quantidade")] 
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        public number Quantidade {get; set}

        [Column ("Unidade")]
        [Required(ErrorMessage = "A unidade é obrigatória")]
        public enum Unidade {get; set}

        [Column ("Observações")]
        [Maxlenght (1000), Minlenght (10)]
        [Required(ErrorMessage = "As observações são obrigatórias")]  
        public string Observacoes {get; set}

        [Column ("Status do Sistema")]
        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool StatusDoSistema {get; set}

        [Column ("PacienteId")]
        public number PacienteId {get; set}

        [Column ("UsuarioId")] 
        public number UsuarioId {get; set}
    }
}