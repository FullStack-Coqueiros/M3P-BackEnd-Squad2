﻿using MedicalCare.Enums;

namespace MedicalCare.DTO
{
    public class DietaGetDto
    {
        public int Id { get; set; }
        public string NomeDaDieta { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public string Tipo { get; set; }
        public string DescricaoDaDietaExecutada { get; set; }
        public bool StatusDoSistema { get; set; }
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
    }
}
