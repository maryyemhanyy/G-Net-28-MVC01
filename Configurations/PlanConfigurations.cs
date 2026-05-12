using GymSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymSystem.Configurations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(50);

            builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(200);

            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 356");
            });

            
            
        }
    }
}
