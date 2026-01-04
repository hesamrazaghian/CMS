using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Persistence.Configurations.Auth;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    #region Configuration

    // Configures the RefreshToken entity mapping and relationships.
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Token)
            .IsRequired( )
            .HasMaxLength(256);

        builder.Property(t => t.CreatedByIp)
            .HasMaxLength(64);

        builder.Property(t => t.UserAgent)
            .HasMaxLength(256);

        builder.Property(t => t.RevokeReason)
            .HasMaxLength(256);

        builder.Property(t => t.ReplaceByToken)
            .HasMaxLength(256);

        builder.HasOne(t => t.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(t => t.UserId);
    }

    #endregion
}
