using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Domain.Assets;

namespace ProjectTracker.Infrastructure.Persistence.Configurations
{
    public class AssetVersionConfiguration : IEntityTypeConfiguration<AssetVersion>
    {
        public void Configure(EntityTypeBuilder<AssetVersion> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.FilePath)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(v => v.VersionNumber)
                   .IsRequired();

            builder.Property(v => v.IsCurrent)
                   .IsRequired();

            builder.Property(v => v.CreatedAt)
                   .IsRequired();
        }
    }
}
