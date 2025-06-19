using ForkliftDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForkliftDirectory.Infrastructure.EntityConfigurations
{
    public class ForkliftDowntimeConfiguration : IEntityTypeConfiguration<ForkliftDowntime>
    {
        public void Configure(EntityTypeBuilder<ForkliftDowntime> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Description).HasMaxLength(100);
            builder.Property(d => d.StartTime).IsRequired();
            builder.Property(d => d.EndTime);
        }
    }
}
