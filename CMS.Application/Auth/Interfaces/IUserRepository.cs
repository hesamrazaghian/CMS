using CMS.Domain.Auth.Entities;

namespace CMS.Application.Auth.Interfaces;

public interface IUserRepository
{
    #region Queries

    // Retrieves a user by its unique identifier.
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    // Retrieves a user by normalized username.
    Task<User?> GetByUsernameAsync(
        string normalizedUsername,
        CancellationToken cancellationToken = default);

    // Retrieves a user by normalized email address.
    Task<User?> GetByEmailAsync(
        string normalizedEmail,
        CancellationToken cancellationToken = default);

    // Checks whether the normalized username is unique.
    Task<bool> IsUsernameUniqueAsync(
        string normalizedUsername,
        Guid? excludeUserId = null,
        CancellationToken cancellationToken = default);

    // Checks whether the normalized email is unique.
    Task<bool> IsEmailUniqueAsync(
        string normalizedEmail,
        Guid? excludeUserId = null,
        CancellationToken cancellationToken = default);

    #endregion

    #region Commands

    // Adds a new user to the data store.
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    // Updates an existing user in the data store.
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    #endregion
}
