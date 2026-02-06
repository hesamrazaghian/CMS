using CMS.Domain.Auth.Entities;
using CMS.Infrastructure.Auth.Persistence.Configurations; // مطمئن شو این Namespace در UserConfiguration هست
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Auth.Persistence.Context;

public class AuthDbContext : DbContext
{
    public AuthDbContext( DbContextOptions<AuthDbContext> options ) : base( options )
    {
    }

    public DbSet<User> Users => Set<User>( );

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );
        modelBuilder.ApplyConfiguration( new UserConfiguration( ) );
    }
}
