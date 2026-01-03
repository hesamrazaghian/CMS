namespace CMS.Domain.Auth.Entities;

/// <summary>
/// Join entity representing the assignment of a role to a user.
/// </summary>
public class UserRole
{
    #region Foreign Keys

    /// <summary>Foreign key to the associated user.</summary>
    public Guid UserId { get; set; }

    /// <summary>Foreign key to the associated role.</summary>
    public Guid RoleId { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>Navigation property to the user.</summary>
    public User User { get; set; } = default!;

    /// <summary>Navigation property to the role.</summary>
    public Role Role { get; set; } = default!;

    #endregion

    #region Audit & Metadata

    /// <summary>Timestamp when the role was assigned to the user (UTC).</summary>
    public DateTimeOffset AssignedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>ID of the user or system that assigned this role (e.g., admin user ID).</summary>
    public string AssignedBy { get; set; } = string.Empty;

    /// <summary>Indicates if this role assignment is currently active.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Optional timestamp when the assignment was deactivated (UTC).</summary>
    public DateTimeOffset? DeactivatedAt { get; set; }

    #endregion
}