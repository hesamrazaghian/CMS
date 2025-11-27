namespace CMS.Domain.Auth.Entities;

public class User
{
    // Unique identifier for the user
    public Guid Id { get; set; } = Guid.NewGuid( );

    // Username (e.g., "john_doe")
    public string Username { get; set; } = string.Empty;

    // Uppercase username for case-insensitive lookups
    public string NormalizedUsername { get; set; } = string.Empty;

    // User's email address
    public string Email { get; set; } = string.Empty;

    // Uppercase email for case-insensitive comparisons
    public string NormalizedEmail { get; set; } = string.Empty;

    // Hashed password (never store plain text!)
    public string PasswordHash { get; set; } = string.Empty;

    // Indicates if the email address has been verified
    public bool EmailConfirmed { get; set; }

    // Optional phone number
    public string PhoneNumber { get; set; } = string.Empty;

    // Indicates if the phone number has been verified
    public bool PhoneNumberConfirmed { get; set; }

    // Enables two-factor authentication for the user
    public bool TwoFactorEnabled { get; set; }

    // Allows account lockout after failed login attempts
    public bool LockoutEnabled { get; set; }

    // End time of lockout period (if locked)
    public DateTimeOffset? LockoutEnd { get; set; }

    // Number of consecutive failed access attempts
    public int AccessFailedCount { get; set; }

    // Timestamp when the user was created (UTC)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Optional timestamp of last profile update (UTC)
    public DateTime? UpdatedAt { get; set; }

    // Timestamp of the user's last successful login (UTC)
    public DateTime? LastLoginAt { get; set; }

    // Timestamp of the last password change (UTC)
    public DateTime? LastPasswordChangeAt { get; set; }

    // Indicates if the user account is active
    public bool IsActive { get; set; } = true;

    // Roles assigned to this user
    public ICollection<Role> Roles { get; set; } = new List<Role>( );

    // Refresh tokens issued for this user
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>( );
}