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
        [Required(ErrorMessage = "O nome do medicamento � obrigat�rio")]
        public string NomeDoMedicamento {get; set;}
        [Required(ErrorMessage = "A data � obrigat�ria")]
        public DateTime Data {get; set;}
        [Required(ErrorMessage = "O tipo de medicamento � obrigat�rio")]
        public EOpcoesMedicamentos Tipo {get; set;}
        [Required(ErrorMessage = "A quantidade � obrigat�ria")]
        public int Quantidade {get; set;}
        [Required(ErrorMessage = "A unidade � obrigat�ria")]
        public EUnidadeMedicamentos Unidade { get; set; }
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Observa��es devem ter entre 10 e 1000 caracteres.")]
        [Required(ErrorMessage = "As observa��es s�o obrigat�rias")]
        public string Observacoes {get;set;}
        [Required(ErrorMessage = "O Status � obrigat�rio")]
        public bool StatusDoSistema {get; set;}
        public int PacienteId {get; set;}
        public int UsuarioId {get; set;}

       
    }
}