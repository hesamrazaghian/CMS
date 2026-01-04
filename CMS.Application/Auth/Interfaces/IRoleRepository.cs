using CMS.Domain.Auth.Entities;

namespace CMS.Application.Auth.Interfaces;

public interface IRoleRepository
{
    #region Queries

    // Retrieves a role by its normalized name.
    Task<Role?> GetByNameAsync(string normalizedName, CancellationToken cancellationToken = default);

    #endregion

    #region Commands

    // Adds a new role to the data store.
    Task AddAsync(Role role, CancellationToken cancellationToken = default);

    #endregion
}
