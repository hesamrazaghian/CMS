namespace CMS.Domain.Auth.Entities;

public class RefreshToken
{
    // Unique identifier for the refresh token
    public Guid Id { get; set; } = Guid.NewGuid( );

    // The actual refresh token string
    public string Token { get; set; } = string.Empty;

    // Expiration time of the token
    public DateTime ExpiresAt { get; set; }

    // Creation timestamp in UTC
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // IP address of the device that requested the token (for security auditing)
    public string CreatedByIp { get; set; } = string.Empty;

    // User agent of the client device (for security and diagnostics)
    public string UserAgent { get; set; } = string.Empty;

    // Indicates whether the token has been revoked
    public bool IsRevoked { get; set; }

    // Timestamp when the token was revoked (if applicable)
    public DateTime? RevokedAt { get; set; }

    // Optional reason for revocation (e.g., "user logged out", "suspicious activity")
    public string RevokeReason { get; set; } = string.Empty;

    // If this token was replaced (e.g., via token rotation), this holds the new token
    public string ReplaceByToken { get; set; } = string.Empty;

    // Foreign key to the associated user
    public Guid UserId { get; set; }

    // Navigation property to the user
    public User User { get; set; } = default!;
}