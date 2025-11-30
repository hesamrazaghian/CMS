using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CMS.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        // Constructor injecting DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #region DbSets // EF Core entity sets

        // Users table
        public DbSet<User> Users => Set<User>( );

        // Roles table
        public DbSet<Role> Roles => Set<Role>( );

        // Refresh tokens table
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>( );

        #endregion

        #region ModelConfig // apply all IEntityTypeConfiguration classes

        // Configure EF Core model mappings
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Base configuration
            base.OnModelCreating(modelBuilder);

            // Apply all configuration classes in current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly( )
            );
        }

        #endregion
    }
}
