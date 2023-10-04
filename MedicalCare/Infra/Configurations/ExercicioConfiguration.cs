using MedicalCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCare.Infra.Configurations
{
    public class ExercicioConfiguration : IEntityTypeConfiguration<ExercicioModel>
    {
        public void Configure(EntityTypeBuilder<ExercicioModel> builder)
        {
            builder.ToTable("Exercicios");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
        }
    }
}
