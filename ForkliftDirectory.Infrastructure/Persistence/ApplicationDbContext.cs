using ForkliftDirectory.Domain.Entities;
using ForkliftDirectory.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ForkliftDirectory.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<ForkliftDowntime> ForkliftDowntimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ForkliftConfiguration());
            modelBuilder.ApplyConfiguration(new ForkliftDowntimeConfiguration());            
        }
    }
}
