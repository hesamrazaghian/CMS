using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using CMS.Infrastructure.Auth.Persistence.Configurations;

namespace CMS.Infrastructure.Auth.Persistence.Context;

public class AuthDbContext : DbContext
{
    public DbSet<User> Users => Set<User>( );

    public AuthDbContext( DbContextOptions<AuthDbContext> options )
        : base( options ) { }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration( new UserConfiguration( ) );
    }
}
