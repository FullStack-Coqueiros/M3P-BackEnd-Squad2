﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCare.Models
{
    [Table("EnderecoModel")]
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string PontoDeReferencia { get; set; }
        public int PacienteId { get; set; }
        public PacienteModel Paciente { get; set; }

    }
}
