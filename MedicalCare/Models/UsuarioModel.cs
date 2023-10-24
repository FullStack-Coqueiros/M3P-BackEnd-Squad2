using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCare.Enums;

namespace MedicalCare.Models
{
    [Table("UsuarioModel")]
    public class UsuarioModel : PessoaModel
    {
        public string Telefone { get; set; }

        public string Senha { get; set; }   

        public string Tipo { get; set; }

        public ICollection <ConsultaModel> Consultas { get; set; }
        public ICollection<DietaModel> Dietas { get; set; }
        public ICollection<ExameModel> Exames { get; set; }
        public ICollection<ExercicioModel> Exercicios { get; set; }
        public ICollection<MedicamentoModel> Medicamentos { get; set; }

    }
}