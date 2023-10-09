using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCare.Enums;

namespace MedicalCare.Models
{
    [Table("USUARIOS")]
    public class UsuarioModel : PessoaModel
    {
        [Column("TELEFONE"), Required(ErrorMessage = "Telefone é obrigatório.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Telefone deve estar no formato (99) 9999-9999")]
        public string Telefone { get; set; }

        [Column ("SENHA"), Required]
        public string Senha { get; set; }   

        [Column ("TIPO"), Required]
        public ETipo Tipo { get; set; }        
    }
}