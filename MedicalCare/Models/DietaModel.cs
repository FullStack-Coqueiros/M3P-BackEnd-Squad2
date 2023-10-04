using System;

using MedicalCare.Enum;

namespace MedicalCare.Models


{
	public  class DietaModel

	{
    public string NomeDaDieta { get; set; }

    public string Descricao { get; set; }

    public DateTime Data { get; set; } 

    public DateTime Horario { get; set; }

    public ETipoDieta Tipo { get; set; }

    public string DescricaoDaDietaExecutada { get; set; }

    public bool StatusDoSistema { get; set; }

    public int PacienteId { get; set; }

    public int UsuarioId { get; set; }

    }



}
