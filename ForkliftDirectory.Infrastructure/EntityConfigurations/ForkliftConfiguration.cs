using ForkliftDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForkliftDirectory.Infrastructure.EntityConfigurations
{
    public class ForkliftConfiguration : IEntityTypeConfiguration<Forklift>
    {
        public void Configure(EntityTypeBuilder<Forklift> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Brand).IsRequired().HasMaxLength(50);
            builder.Property(f => f.Number).IsRequired().HasMaxLength(50);
            builder.Property(f => f.LoadCapacity).HasColumnType("decimal(10,2)");
            builder.Property(f => f.UpdatedAt).HasMaxLength(100);

            builder.HasMany(f => f.Downtimes)
                .WithOne(d => d.Forklift)
                .HasForeignKey(d => d.ForkliftId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
