using MedicalCare.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCare.DTO
{
    public class MedicamentoUpdateDTO
    {
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 100 caracteres.")]
        [Required(ErrorMessage = "O nome do medicamento é obrigatório")]
        public string NomeDoMedicamento {get; set;}
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data {get; set;}
        [Required(ErrorMessage = "O tipo de medicamento é obrigatório")]
        public EOpcoesMedicamentos Tipo {get; set;}
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        public int Quantidade {get; set;}
        [Required(ErrorMessage = "A unidade é obrigatória")]
        public EUnidadeMedicamentos Unidade { get; set; }
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Observações devem ter entre 10 e 1000 caracteres.")]
        [Required(ErrorMessage = "As observações são obrigatórias")]
        public string Observacoes {get;set;}
        [Required(ErrorMessage = "O Status é obrigatório")]
        public bool StatusDoSistema {get; set;}
        public int PacienteId {get; set;}
        public int UsuarioId {get; set;}

       
    }
}