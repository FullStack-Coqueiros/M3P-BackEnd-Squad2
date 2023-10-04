using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCare.Models
{
    [Table("Medicmantos")]
    public class MedicamentosModel
    {
        [Maxlenght(100), Minilenght(5)]
        public string NomeDoMedicamento {get; set;}
        public DateTime {get; set;}

        public DateTime.Now {get; set;}

        public string Tipo {get;set;}

        public string Opcoes {get; set}

        public number Quantidade {get; set}

        public string Unidade {get; set}

        public string Observacoes {get; set}

        public bool StatusDoSistema {get; set}

        public number PacienteId {get; set}

        public number UsuarioId {get; set}
    }
}