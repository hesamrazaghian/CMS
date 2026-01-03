using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CMS.Infrastructure.Persistence;

/// <summary>
/// Main database context for the CMS application.
/// </summary>
public class AppDbContext : DbContext
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="AppDbContext"/> with the specified options.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    #endregion

    #region DbSets

    /// <summary>Users table.</summary>
    public DbSet<User> Users => Set<User>( );

    /// <summary>Roles table.</summary>
    public DbSet<Role> Roles => Set<Role>( );

    /// <summary>User-role assignments with audit metadata.</summary>
    public DbSet<UserRole> UserRoles => Set<UserRole>( );

    /// <summary>Refresh tokens for secure authentication flows.</summary>
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>( );

    #endregion

    #region Model Configuration

    /// <summary>
    /// Configures the model by applying entity configurations from the current assembly.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all IEntityTypeConfiguration classes in this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly( ));
    }

    #endregion
}