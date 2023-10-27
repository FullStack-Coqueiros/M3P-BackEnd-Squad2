using MedicalCare.Enums;
using MedicalCare.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Infra
{
    public class MedicalCareDbContext : DbContext
    {
        public DbSet<EnderecoModel> DbEndereco { get; set; }
        public DbSet<ExercicioModel> DbExercicio { get; set; }
        public DbSet<PacienteModel> DbPaciente { get; set; }
        public DbSet<ExameModel> DbExame { get; set; }
        public DbSet<DietaModel> DbDieta { get; set; }
        public DbSet<ConsultaModel> DbConsulta { get; set; }
        public DbSet<LogModel> DbLog { get; set; }
        //fazr dbset de medicamentos

        public MedicalCareDbContext(DbContextOptions<MedicalCareDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteModel>()
                .HasOne(h => h.Endereco)
                .WithOne(w => w.Paciente)
                .HasForeignKey<EnderecoModel>(h => h.PacienteId)
                .IsRequired();

            modelBuilder.Entity<PacienteModel>()
                .HasMany(h => h.Exames)
                .WithOne(w => w.Paciente)
                .HasForeignKey(h => h.PacienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<PacienteModel>()
                .HasMany(h => h.Consultas)
                .WithOne(w => w.Paciente)
                .HasForeignKey(h => h.PacienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<PacienteModel>()
               .HasMany(h => h.Dietas)
               .WithOne(w => w.Paciente)
               .HasForeignKey(h => h.PacienteId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<PacienteModel>()
               .HasMany(h => h.Exercicios)
               .WithOne(w => w.Paciente)
               .HasForeignKey(h => h.PacienteId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<PacienteModel>()
               .HasMany(h => h.Medicamentos)
               .WithOne(w => w.Paciente)
               .HasForeignKey(h => h.PacienteId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Consultas)
                .HasForeignKey(h => h.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<DietaModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Dietas)
                .HasForeignKey(h => h.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<ExameModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Exames)
                .HasForeignKey(h => h.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<ExercicioModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Exercicios)
                .HasForeignKey(h => h.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<MedicamentoModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Medicamentos)
                .HasForeignKey(h => h.UsuarioId)
                .IsRequired();


            modelBuilder.Entity<UsuarioModel>().HasData(

                new UsuarioModel
                {
                    Id = 1,
                    NomeCompleto = "José Alves",
                    Genero = "Masculino",
                    Cpf = "09465328956",
                    Email = "jose85@gmail.com",
                    StatusDoSistema = true,
                    Telefone = "48998561254",
                    Senha = "12345678",
                    Tipo = "Administrador"
                },
                new UsuarioModel
                {
                    Id = 2,
                    NomeCompleto = "André Souza",
                    Genero = "Masculino",
                    Cpf = "03262548652",
                    Email = "andresz@gmail.com",
                    StatusDoSistema = true,
                    Telefone = "48995321544",
                    Senha = "12345678",
                    Tipo = "Médico"
                },
                new UsuarioModel
                {
                    Id = 3,
                    NomeCompleto = "Julio Matos Siqueira",
                    Genero = "Masculino",
                    Cpf = "06532589965",
                    Email = "julioms@gmail.com",
                    StatusDoSistema = true,
                    Telefone = "48995874233",
                    Senha = "12345678",
                    Tipo = "Enfermeiro"
                },
                 new UsuarioModel
                 {
                     Id = 4,
                     NomeCompleto = "Ademar Fonseca",
                     Genero = "Masculino",
                     Cpf = "06523144785",
                     Email = "ademar84@gmail.com",
                     StatusDoSistema = true,
                     Telefone = "48996524233",
                     Senha = "12345678",
                     Tipo = "Médico"
                 }
                );

            modelBuilder.Entity<PacienteModel>().HasData(
                new PacienteModel
                {
                    Id = 1,
                    NomeCompleto = "Amanda Siqueira",
                    Genero = "Feminino",
                    Cpf = "09856326588",
                    Email = "amandasq95@gmail.com",
                    StatusDoSistema = true,
                    DataDeNascimento = new DateTime(1980, 5, 15),
                    Rg = "1234567",
                    EstadoCivil = "Casado",
                    Telefone = "(11) 555-1234",
                    Naturalidade = "São Paulo, SP",
                    ContatoDeEmergencia = "48996325484",
                    Alergias = "Nenhuma alergia conhecida",
                    CuidadosEspecificos = "Nenhum cuidado específico",
                    Convenio = "Plano de Saúde ABC",
                    NumeroDoConvenio = "98765432",
                    ValidadeDoConvenio = new DateTime(2024, 12, 31)
                },
                new PacienteModel
                {
                    Id = 2,
                    NomeCompleto = "Patrícia Santos",
                    Genero = "Feminino",
                    Cpf = "09856322658",
                    Email = "patisantos@gmail.com",
                    StatusDoSistema = true,
                    DataDeNascimento = new DateTime(1995, 9, 22),
                    Rg = "9876543",
                    EstadoCivil = "Solteiro",
                    Telefone = "(21) 555-4321",
                    Naturalidade = "Rio de Janeiro, RJ",
                    ContatoDeEmergencia = "48998487752",
                    Alergias = "Pólen",
                    CuidadosEspecificos = "Uso de medicação para alergia",
                    Convenio = "Plano de Saúde XYZ",
                    NumeroDoConvenio = "12345678",
                    ValidadeDoConvenio = new DateTime(2023, 10, 15),
                },
                new PacienteModel
                {
                    Id = 3,
                    NomeCompleto = "Rogério Antunnes Scretzh",
                    Genero = "Masculino",
                    Cpf = "09987452685",
                    Email = "rogerio@gmail.com",
                    StatusDoSistema = true,
                    DataDeNascimento = new DateTime(1972, 3, 10),
                    Rg = "5555555",
                    EstadoCivil = "Divorciado",
                    Telefone = "(31) 555-9876",
                    Naturalidade = "Belo Horizonte, MG",
                    ContatoDeEmergencia = "48999852131",
                    Alergias = "Nenhuma alergia conhecida",
                    CuidadosEspecificos = "Nenhum cuidado específico",
                    Convenio = "Plano de Saúde DEF",
                    NumeroDoConvenio = "24681357",
                    ValidadeDoConvenio = new DateTime(2024, 11, 30)
                },
                new PacienteModel
                {
                    Id = 4,
                    NomeCompleto = "Emersom Junior Mattos",
                    Genero = "Masculino",
                    Cpf = "09855633254",
                    Email = "emersom@gmail.com",
                    StatusDoSistema = true,
                    DataDeNascimento = new DateTime(1990, 7, 8),
                    Rg = "7654321",
                    EstadoCivil = "Solteira",
                    Telefone = "(48) 555-6789",
                    Naturalidade = "Florianópolis, SC",
                    ContatoDeEmergencia = "48995623266",
                    Alergias = "Nenhuma alergia conhecida",
                    CuidadosEspecificos = "Nenhum cuidado específico",
                    Convenio = "Plano de Saúde GHI",
                    NumeroDoConvenio = "98761234",
                    ValidadeDoConvenio = new DateTime(2023, 9, 15)
                }
                );
            modelBuilder.Entity<ConsultaModel>().HasData(
                new ConsultaModel
                {
                    Id = 1,
                    MotivoDaConsulta = "Dor de cabeça persistente",
                    DataDaConsulta = DateTime.Now.AddDays(-7), 
                    HorarioDaConsulta = DateTime.Now.AddHours(-8),
                    DescricaoDoProblema = "Paciente relatou dor de cabeça recorrente nas últimas duas semanas.",
                    MedicacaoReceitada = "Paracetamol",
                    DosagemEPrecaucoes = "Tomar um comprimido a cada 4 horas. Evitar o consumo de álcool durante o tratamento.",
                    StatusDoSistema = true,
                    PacienteId = 1,
                    UsuarioId = 2
                },
                new ConsultaModel
                {
                    Id = 2,
                    MotivoDaConsulta = "Check-up anual",
                    DataDaConsulta = DateTime.Now.AddDays(-30), 
                    HorarioDaConsulta = DateTime.Now.AddHours(3), 
                    DescricaoDoProblema = "O paciente não relata nenhum problema específico, mas deseja um check-up geral.",
                    MedicacaoReceitada = null, 
                    DosagemEPrecaucoes = "Nenhuma medicação prescrita neste momento.",
                    StatusDoSistema = true,
                    PacienteId = 2,
                    UsuarioId = 3
                },
                new ConsultaModel
                {
                    Id = 3,
                    MotivoDaConsulta = "Febre e tosse persistente",
                    DataDaConsulta = DateTime.Now.AddDays(-5), 
                    HorarioDaConsulta = DateTime.Now.AddHours(-3), 
                    DescricaoDoProblema = "O paciente relata febre alta e tosse constante há uma semana.",
                    MedicacaoReceitada = "Antibiótico",
                    DosagemEPrecaucoes = "Tomar o antibiótico de 8 em 8 horas com alimentos. Evitar o consumo de laticínios durante o tratamento.",
                    StatusDoSistema = true,
                    PacienteId = 3,
                    UsuarioId = 3
                },
                new ConsultaModel
                {
                    Id = 4,
                    MotivoDaConsulta = "Consulta de rotina anual",
                    DataDaConsulta = DateTime.Now.AddDays(-365), 
                    HorarioDaConsulta = DateTime.Now.AddHours(-10), 
                    DescricaoDoProblema = "O paciente não apresenta queixas específicas, apenas uma verificação anual de sua saúde.",
                    MedicacaoReceitada = null, 
                    DosagemEPrecaucoes = "Nenhuma medicação prescrita para esta consulta de rotina.",
                    StatusDoSistema = true,
                    PacienteId = 1,
                    UsuarioId = 1
                }
                );
            modelBuilder.Entity<ExameModel>().HasData(
                new ExameModel
                {
                    Id = 1,
                    NomeDoExame = "Hemograma Completo",
                    DataDoExame = DateTime.Now.AddDays(-10), 
                    HorarioDoExame = DateTime.Now.AddHours(-1), 
                    TipoDoExame = "Exame de Sangue",
                    Laboratorio = "Laboratório ABC",
                    UrlDoDocumento = "http://www.laboratorioabc.com/exames/hemograma-completo",
                    Resultados = "Hemoglobina: 14 g/dL, Leucócitos: 7500/mm³, Plaquetas: 250000/mm³, ...",
                    StatusDoSistema = true,
                    PacienteId = 1,
                    UsuarioId = 1
                },
                new ExameModel
                {
                    Id = 2,
                    NomeDoExame = "Raios-X do Tórax",
                    DataDoExame = DateTime.Now.AddDays(-30), 
                    HorarioDoExame = DateTime.Now.AddHours(-7),
                    TipoDoExame = "Imagem",
                    Laboratorio = "Centro de Radiologia XYZ",
                    UrlDoDocumento = "http://www.centroradiologiaxyz.com/exames/raios-x-torax",
                    Resultados = "Raios-X do tórax mostraram uma radiografia normal, sem anomalias.",
                    StatusDoSistema = true,
                    PacienteId = 2,
                    UsuarioId = 3
                },
                new ExameModel
                {
                    Id = 3,
                    NomeDoExame = "Ultrassonografia Abdominal",
                    DataDoExame = DateTime.Now.AddDays(-45), 
                    HorarioDoExame = DateTime.Now.AddHours(8),
                    TipoDoExame = "Imagem",
                    Laboratorio = "Clinica de Ultrassonografia ABC",
                    UrlDoDocumento = "http://www.ultrassonografiaabc.com/exames/ultrassonografia-abdominal",
                    Resultados = "Ultrassonografia abdominal não revelou anomalias significativas no fígado e no pâncreas.",
                    StatusDoSistema = true,
                    PacienteId = 2,
                    UsuarioId = 2
                }
                );
            modelBuilder.Entity<EnderecoModel>().HasData(
                new EnderecoModel
                {
                    Id = 1,
                    Cep = "88000-001",
                    Cidade = "Florianópolis",
                    Estado = "SC",
                    Logradouro = "Avenida Beira Mar Norte",
                    Numero = "123",
                    Complemento = "Apto 4",
                    Bairro = "Centro",
                    PontoDeReferencia = "Próximo ao shopping",
                    PacienteId = 1,
                },
                new EnderecoModel
                {
                    Id = 2,
                    Cep = "88040-123",
                    Cidade = "Florianópolis",
                    Estado = "SC",
                    Logradouro = "Rua das Palmeiras",
                    Numero = "456",
                    Complemento = "Casa 2",
                    Bairro = "Trindade",
                    PontoDeReferencia = "Próximo à universidade",
                    PacienteId = 2,
                },
                new EnderecoModel
                {
                    Id = 3,
                    Cep = "88070-789",
                    Cidade = "Florianópolis",
                    Estado = "SC",
                    Logradouro = "Avenida dos Ingleses",
                    Numero = "789",
                    Complemento = "Loja 5",
                    Bairro = "Ingleses",
                    PontoDeReferencia = "Próximo à praia",
                    PacienteId = 3,
                },
                new EnderecoModel
                {
                    Id = 4,
                    Cep = "88130-123",
                    Cidade = "Palhoça",
                    Estado = "SC",
                    Logradouro = "Rua das Palmeiras",
                    Numero = "456",
                    Complemento = "Casa 2",
                    Bairro = "Centro",
                    PontoDeReferencia = "Próximo à praça da cidade",
                    PacienteId = 4
                }
                );

        }
    }

}
