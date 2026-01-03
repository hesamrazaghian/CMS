using CMS.Domain.Auth.Entities;

namespace CMS.Application.Auth.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string normalizedName, CancellationToken cancellationToken = default);
    Task AddAsync(Role role, CancellationToken cancellationToken = default);
}