using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CMS.Domain.Auth.Entities;

namespace CMS.Infrastructure.Auth.Persistence.Configurations;

public class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure( EntityTypeBuilder<User> builder )
    {
        builder.ToTable( "Users" );

        builder.HasKey( x => x.Id );

        builder.Property( x => x.Username )
            .HasMaxLength( 50 )
            .IsRequired( );

        builder.Property( x => x.Email )
            .HasMaxLength( 256 )
            .IsRequired( );

        builder.HasIndex( x => x.Email ).IsUnique( );
        builder.HasIndex( x => x.Username ).IsUnique( );
    }
}
