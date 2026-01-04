using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Persistence.Configurations.Auth;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    #region Configuration

    // Configures the User entity mapping and constraints.
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired( )
            .HasMaxLength(64);

        builder.Property(u => u.NormalizedUsername)
            .IsRequired( )
            .HasMaxLength(64);

        builder.Property(u => u.Email)
            .HasMaxLength(128);

        builder.Property(u => u.NormalizedEmail)
            .HasMaxLength(128);

        builder.Property(u => u.PasswordHash)
            .IsRequired( )
            .HasMaxLength(512);

        builder.HasIndex(u => u.NormalizedUsername)
            .IsUnique( );

        builder.HasIndex(u => u.NormalizedEmail);
    }

    #endregion
}
