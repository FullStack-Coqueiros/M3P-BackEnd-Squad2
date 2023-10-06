using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCare.DTO
{
    public class MedicamentoUpdateDTO
    {
         public string NomeDoMedicamento {get; set;}
        public DateTime Data {get; set;}
        public string Tipo {get; set;}
        public string Opcoes {get; set;}
        public int Quantidade {get; set;}
        public string Observacoes {get;set;}
        public bool StatusDoSistema {get; set;}
        public int PacienteId {get; set;}
        public int UsuarioId {get; set;}

       
    }
}