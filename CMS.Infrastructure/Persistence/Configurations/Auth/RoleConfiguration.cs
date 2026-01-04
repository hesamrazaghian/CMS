using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Persistence.Configurations.Auth;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    #region Configuration

    // Configures the Role entity mapping and constraints.
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired( )
            .HasMaxLength(64);

        builder.Property(r => r.NormalizedName)
            .IsRequired( )
            .HasMaxLength(64);

        builder.Property(r => r.Description)
            .HasMaxLength(256);

        builder.Property(r => r.IsSystemRole)
            .HasDefaultValue(false);

        builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasIndex(r => r.NormalizedName)
            .IsUnique( );
    }

    #endregion
}
