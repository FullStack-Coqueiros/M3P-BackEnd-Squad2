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

        public MedicalCareDbContext(DbContextOptions<MedicalCareDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Consultas)
                .HasForeignKey(h => h.UsuarioId);

            modelBuilder.Entity<DietaModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Dietas)
                .HasForeignKey(h => h.UsuarioId);

            modelBuilder.Entity<ExameModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Exames)
                .HasForeignKey(h => h.UsuarioId);

            modelBuilder.Entity<ExercicioModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Exercicios)
                .HasForeignKey(h => h.UsuarioId);

            modelBuilder.Entity<MedicamentoModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Medicamentos)
                .HasForeignKey(h => h.UsuarioId);

            //    modelBuilder.Entity<PacienteModel>()
            //        .HasOne(h => h.Endereco)
            //        .WithMany(w => w.Pacientes)
            //        .HasForeignKey(h => h.EnderecoId);
            //}
        }
    }
 
}
