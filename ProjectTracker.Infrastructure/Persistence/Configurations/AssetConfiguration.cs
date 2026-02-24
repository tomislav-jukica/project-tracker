using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Domain.Assets;

namespace ProjectTracker.Infrastructure.Persistence.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.Type)
                   .IsRequired();

            builder.Property(a => a.Status)
                   .IsRequired();

            // Versions relationship
            builder.HasMany(a => a.Versions)
                   .WithOne()
                   .HasForeignKey("AssetId")
                   .IsRequired();

            // Tags many-to-many
            builder.HasMany(a => a.Tags)
                   .WithMany();
        }
    }
}
