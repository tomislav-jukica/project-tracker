using Microsoft.EntityFrameworkCore;
using ProjectTracker.Domain.Assets;
using ProjectTracker.Domain.Projects;
using ProjectTracker.Domain.Tags;

namespace ProjectTracker.Infrastructure.Persistence
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options)
            : base(options) { }

        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<AssetVersion> AssetVersions => Set<AssetVersion>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Project> Projects => Set<Project>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssetDbContext).Assembly);
        }
    }
}