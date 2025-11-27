namespace CMS.Domain.Auth.Entities;

public class Role
{
    // Unique identifier for the role
    public Guid Id { get; set; } = Guid.NewGuid( );

    // Display name of the role
    public string Name { get; set; } = string.Empty;

    // Uppercase version for case-insensitive lookups
    public string NormalizedName { get; set; } = string.Empty;

    // Description for the admin panel
    public string Description { get; set; } = string.Empty;

    // Indicates if the role is a non-deletable system role (e.g., Admin)
    public bool IsSystemRole { get; set; } = false;

    // Creation timestamp in UTC
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Optional last update timestamp in UTC
    public DateTime? UpdatedAt { get; set; }

    // Users assigned to this role
    public ICollection<User> Users { get; set; } = default!;
}