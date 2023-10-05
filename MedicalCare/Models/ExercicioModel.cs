﻿using System.ComponentModel.DataAnnotations;

namespace MedicalCare.Models
{
    public class ExercicioModel
    {
        //Creio que será uma relação n x n, visto que um tipo de exercicio pode estar presente em varios prontuarios,
        //e um paciente pode ter varios tipos de exercicios prescritos

        public int Id { get; set; }
        // [MinLength(5)], possivelmente terei que usar esta dataAnnotation, pois o IEntityTypeConfiguration não possui método minLength.
        public string NomeDaSerieDeExercicios { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public string Tipo { get; set; } //Mudar para enum
        public int QuantidadePorSemana { get; set; }
        public string Descricao { get; set; }
        public bool StatusNoSistema { get; set; }
        public int UsuarioId { get; set; } 
        public int PacienteId { get; set; } // Possivel Icollection, pois podem haver varios
    }
}