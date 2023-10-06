using Microsoft.EntityFrameworkCore;

namespace MedicalCare.Models
{
    public class MedicalCareDbContext : DbContext
    {
        public DbSet<ExameModel> ExameModels { get; set; }
        public DbSet<DietaModel> DietaModels { get; set; }

        public MedicalCareDbContext(DbContextOptions<MedicalCareDbContext> options) : base(options)
        {

            //aqui vai a relação entre as tabelas
        }
    }
}
