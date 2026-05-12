using GymSystem.Configurations;
using GymSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace GymSystem.DbContexts   
{
    public class GYMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;database=Gym;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new Configurations.PlanConfigurations());
        }
    }
}
