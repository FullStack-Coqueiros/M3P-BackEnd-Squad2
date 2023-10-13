using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedicalCare.Enums;

namespace MedicalCare.Models
{
    [Table("Medicamentos")]
    public class MedicamentosModel
    {
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

        [Column ("Opções")]
        public EOpcoesMedicamentos Opcoes {get; set;}

        [Column ("Quantidade")] 
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        public int Quantidade {get; set;}

        [Column ("Unidade")]
        [Required(ErrorMessage = "A unidade é obrigatória")]
        public EUnidadeMedicamentos Unidade {get; set;}

        [Column ("Observações")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Observações devem ter entre 10 e 1000 caracteres.")]
        [Required(ErrorMessage = "As observações são obrigatórias")]  
        public string Observacoes {get; set;}

        [Column ("Status do Sistema")]
        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool StatusDoSistema {get; set;}

        [Column ("PacienteId")]
        public int PacienteId {get; set;}

        [Column ("UsuarioId")] 
        public int UsuarioId {get; set;}
    }
}