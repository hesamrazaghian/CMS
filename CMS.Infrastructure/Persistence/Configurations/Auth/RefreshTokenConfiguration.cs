using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Persistence.Configurations.Auth;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        // Map to the "RefreshTokens" table
        builder.ToTable("RefreshTokens");

        // Define primary key
        builder.HasKey(t => t.Id);

        // Token string is required and limited to 256 characters
        builder.Property(t => t.Token)
            .IsRequired( )
            .HasMaxLength(256);

        // IP address of the client that requested the token
        builder.Property(t => t.CreatedByIp)
            .HasMaxLength(64);

        // User agent string for client identification
        builder.Property(t => t.UserAgent)
            .HasMaxLength(256);

        // Optional revocation reason (e.g., security policy, logout)
        builder.Property(t => t.RevokeReason)
            .HasMaxLength(256);

        // Stores the new token if this one was rotated
        builder.Property(t => t.ReplaceByToken)
            .HasMaxLength(256);

        // One-to-many relationship: one user can have many refresh tokens
        builder.HasOne(t => t.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(t => t.UserId);
    }
}