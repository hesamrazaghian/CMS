using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>( );

    public AppDbContext( DbContextOptions<AppDbContext> options )
        : base( options ) { }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration( new UserConfiguration( ) );
    }
}
