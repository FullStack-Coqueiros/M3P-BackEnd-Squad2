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

        public MedicalCareDbContext(){ }
        public MedicalCareDbContext(DbContextOptions<MedicalCareDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-BG5E4QK\\SQLEXPRESS;Database=LabMedicineBd;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
