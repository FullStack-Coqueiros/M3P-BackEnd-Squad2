using System;
using System.ComponentModel.DataAnnotations;


namespace MedicalCare.DTO
{
    public class ExameUpdateDto
    {
        [Required(ErrorMessage = "O Nome do Exame é obrigatório.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O Nome do Exame deve ter entre 8 e 64 caracteres.")]
        public string NomeDoExame { get; set; }

        [Required(ErrorMessage = "A Data do Exame é obrigatória.")]
        public DateTime DataDoExame { get; set; }

        [Required(ErrorMessage = "O Horário do Exame é obrigatório.")]
        public DateTime HorarioDoExame { get; set; }

        [Required(ErrorMessage = "O Tipo do Exame é obrigatório.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O Tipo do Exame deve ter entre 4 e 32 caracteres.")]
        public string TipoDoExame { get; set; }

        [Required(ErrorMessage = "O Laboratório é obrigatório.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O Laboratório deve ter entre 4 e 32 caracteres.")]
        public string Laboratorio { get; set; }

        [Url(ErrorMessage = "A URL do Documento não é válida.")]
        public string UrlDoDocumento { get; set; }

        [Required(ErrorMessage = "Os Resultados são obrigatórios.")]
        [StringLength(1024, MinimumLength = 16, ErrorMessage = "Os Resultados devem ter entre 16 e 1024 caracteres.")]
        public string Resultados { get; set; }

        [Required(ErrorMessage = "O Status do Sistema é obrigatório.")]
        public bool StatusDoSistema { get; set; }

        [Required(ErrorMessage = "O Id do Paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O Id do Usuário é obrigatório.")]
        public int UsuarioId { get; set; }

    }
}
