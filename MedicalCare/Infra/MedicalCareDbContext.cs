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

            //fzr relacionamento consulta e paciente, evitar deleção em cascata
            //fzr relação diete e paciente, evitar deleção em cascata
            //fzr relação exercicio e paciente, evitar deleção em cascata
            //fzr relação exame e paciente, evitar deleção em cascata
            //fzr relação medicamentos e paciente, evitar deleção em cascata


            modelBuilder.Entity<ConsultaModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Consultas)
                .HasForeignKey(h => h.UsuarioId); // marcar como obrigatório


            modelBuilder.Entity<DietaModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Dietas)
                .HasForeignKey(h => h.UsuarioId); //Marcar como obrigatório


            modelBuilder.Entity<ExameModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Exames)
                .HasForeignKey(h => h.UsuarioId);//Marcar como obrigatório

            modelBuilder.Entity<ExercicioModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Exercicios)
                .HasForeignKey(h => h.UsuarioId); //Marcar como obrigatório

            modelBuilder.Entity<MedicamentoModel>()
                .HasOne(h => h.Usuario)
                .WithMany(w => w.Medicamentos)
                .HasForeignKey(h => h.UsuarioId); //Marcar como obrigatório
        }
    }
 
}
