namespace CMS.Domain.Auth.Entities;

/// <summary>
/// Represents a refresh token used for obtaining new access tokens.
/// </summary>
public class RefreshToken
{
    #region Identity

    /// <summary>Unique identifier for the refresh token.</summary>
    public Guid Id { get; set; } = Guid.NewGuid( );

    /// <summary>The actual refresh token string (typically a long random string).</summary>
    public string Token { get; set; } = string.Empty;

    #endregion

    #region Lifetime

    /// <summary>Expiration time of the token.</summary>
    public DateTimeOffset ExpiresAt { get; set; }

    /// <summary>Creation timestamp in UTC.</summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    #endregion

    #region Security Context

    /// <summary>IP address of the device that requested the token (for security auditing).</summary>
    public string CreatedByIp { get; set; } = string.Empty;

    /// <summary>User agent of the client device (for security and diagnostics).</summary>
    public string UserAgent { get; set; } = string.Empty;

    #endregion

    #region Revocation

    /// <summary>Indicates whether the token has been revoked.</summary>
    public bool IsRevoked { get; set; }

    /// <summary>Timestamp when the token was revoked (if applicable).</summary>
    public DateTimeOffset? RevokedAt { get; set; }

    /// <summary>Optional reason for revocation (e.g., "user logged out", "suspicious activity").</summary>
    public string RevokeReason { get; set; } = string.Empty;

    #endregion

    #region Token Rotation

    /// <summary>If this token was replaced (e.g., via token rotation), this holds the new token value.</summary>
    public string ReplaceByToken { get; set; } = string.Empty;

    #endregion

    #region Foreign Key & Navigation

    /// <summary>Foreign key to the associated user.</summary>
    public Guid UserId { get; set; }

    /// <summary>Navigation property to the user.</summary>
    public User User { get; set; } = default!;

    #endregion
}