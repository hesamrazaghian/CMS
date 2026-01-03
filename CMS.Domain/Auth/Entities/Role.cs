namespace CMS.Domain.Auth.Entities;

/// <summary>
/// Represents a role that can be assigned to users for authorization.
/// </summary>
public class Role
{
    #region Identity

    /// <summary>Unique identifier for the role.</summary>
    public Guid Id { get; set; } = Guid.NewGuid( );

    /// <summary>Display name of the role (e.g., "Admin", "Editor").</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Uppercase version for case-insensitive lookups.</summary>
    public string NormalizedName { get; set; } = string.Empty;

    #endregion

    #region Metadata

    /// <summary>Description for the admin panel or audit purposes.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Indicates if the role is a non-deletable system role (e.g., Admin).</summary>
    public bool IsSystemRole { get; set; } = false;

    #endregion

    #region Audit

    /// <summary>Creation timestamp in UTC.</summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>Optional last update timestamp in UTC.</summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>Users assigned to this role (many-to-many via UserRole).</summary>
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>( );

    #endregion
}
