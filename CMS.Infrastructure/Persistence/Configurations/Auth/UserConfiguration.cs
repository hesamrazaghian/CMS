using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Persistence.Configurations.Auth;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Map to the "Users" table
        builder.ToTable("Users");

        // Define primary key
        builder.HasKey(u => u.Id);

        // Username is required and limited to 64 characters
        builder.Property(u => u.Username)
            .IsRequired( )
            .HasMaxLength(64);

        // Normalized username for case-insensitive uniqueness
        builder.Property(u => u.NormalizedUsername)
            .IsRequired( )
            .HasMaxLength(64);

        // Email is optional and limited to 128 characters
        builder.Property(u => u.Email)
            .HasMaxLength(128);

        // Normalized email for efficient lookups
        builder.Property(u => u.NormalizedEmail)
            .HasMaxLength(128);

        // Ensure usernames are unique (case-insensitive)
        builder.HasIndex(u => u.NormalizedUsername)
            .IsUnique( );

        // Index on normalized email for faster queries
        builder.HasIndex(u => u.NormalizedEmail);

        // Password hash is required and stored securely
        builder.Property(u => u.PasswordHash)
            .IsRequired( )
            .HasMaxLength(512);

        // Configure many-to-many relationship with Role
        builder
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));
    }
}