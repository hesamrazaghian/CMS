namespace CMS.Domain.Auth.Entities;

/// <summary>
/// Represents a user account in the system.
/// </summary>
public class User
{
    #region Identity

    /// <summary>Unique identifier for the user.</summary>
    public Guid Id { get; set; } = Guid.NewGuid( );

    /// <summary>Username for login (e.g., "john_doe").</summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>Uppercase username for case-insensitive lookups.</summary>
    public string NormalizedUsername { get; set; } = string.Empty;

    #endregion

    #region Contact Info

    /// <summary>User's email address.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Uppercase email for case-insensitive comparisons.</summary>
    public string NormalizedEmail { get; set; } = string.Empty;

    /// <summary>Optional phone number.</summary>
    public string PhoneNumber { get; set; } = string.Empty;

    #endregion

    #region Security

    /// <summary>Hashed password (never store plain text!).</summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>Indicates if the email address has been verified.</summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>Indicates if the phone number has been verified.</summary>
    public bool PhoneNumberConfirmed { get; set; }

    /// <summary>Enables two-factor authentication for the user.</summary>
    public bool TwoFactorEnabled { get; set; }

    /// <summary>Allows account lockout after failed login attempts.</summary>
    public bool LockoutEnabled { get; set; }

    /// <summary>End time of lockout period (if locked).</summary>
    public DateTimeOffset? LockoutEnd { get; set; }

    /// <summary>Number of consecutive failed access attempts.</summary>
    public int AccessFailedCount { get; set; }

    #endregion

    #region Audit & Lifecycle

    /// <summary>Timestamp when the user was created (UTC).</summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>Optional timestamp of last profile update (UTC).</summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>Timestamp of the user's last successful login (UTC).</summary>
    public DateTimeOffset? LastLoginAt { get; set; }

    /// <summary>Timestamp of the last password change (UTC).</summary>
    public DateTimeOffset? LastPasswordChangeAt { get; set; }

    /// <summary>Indicates if the user account is active.</summary>
    public bool IsActive { get; set; } = true;

    #endregion

    #region Navigation Properties

    /// <summary>Roles assigned to this user.</summary>
    public ICollection<Role> Roles { get; set; } = new List<Role>( );

    /// <summary>Refresh tokens issued for this user.</summary>
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>( );

    #endregion
}