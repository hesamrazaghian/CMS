using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CMS.Infrastructure.Persistence;

/// <summary>
/// Represents the main EF Core database context for the CMS.
/// </summary>
public class AppDbContext : DbContext
{
    #region Constructor

    // Initializes the database context with injected options.
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    #endregion

    #region DbSets

    // Represents the users table.
    public DbSet<User> Users => Set<User>( );
    // Represents the roles table.
    public DbSet<Role> Roles => Set<Role>( );
    // Represents the junction table between users and roles.
    public DbSet<UserRole> UserRoles => Set<UserRole>( );
    // Represents refresh tokens used for authentication.
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>( );

    #endregion

    #region Model Configuration

    // Applies all entity configurations from the current assembly.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly( ));
    }

    #endregion
}