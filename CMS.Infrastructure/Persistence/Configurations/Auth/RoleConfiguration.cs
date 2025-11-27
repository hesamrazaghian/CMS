using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CMS.Infrastructure.Persistence.Configurations.Auth;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Map to the "Roles" table
        builder.ToTable("Roles");

        // Define primary key
        builder.HasKey(r => r.Id);

        // Role name is required and limited to 64 characters
        builder.Property(r => r.Name)
            .IsRequired( )
            .HasMaxLength(64);

        // Normalized role name for case-insensitive uniqueness
        builder.Property(r => r.NormalizedName)
            .IsRequired( )
            .HasMaxLength(64);

        // Ensure normalized role names are unique
        builder.HasIndex(r => r.NormalizedName)
            .IsUnique( );

        // Optional description with a max length of 256 characters
        builder.Property(r => r.Description)
            .HasMaxLength(256);

        // System roles (e.g., Admin) cannot be deleted; defaults to false
        builder.Property(r => r.IsSystemRole)
            .HasDefaultValue(false);

        // Auto-set creation timestamp using database server time
        builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}