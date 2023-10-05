using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Infra
{
    public class MedicalCareDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-BG5E4QK\\SQLEXPRESS;Database=LabMedicineBd;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}
