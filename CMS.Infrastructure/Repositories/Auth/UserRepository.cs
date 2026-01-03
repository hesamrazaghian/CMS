using CMS.Application.Auth.Interfaces;
using CMS.Domain.Auth.Entities;
using CMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories.Auth;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(
        string normalizedUsername,
        CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(
                u => u.NormalizedUsername == normalizedUsername,
                cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(
        string normalizedEmail,
        CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(
                u => u.NormalizedEmail == normalizedEmail,
                cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
    }

    public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        return Task.CompletedTask;
    }

    public async Task<bool> IsUsernameUniqueAsync(
        string normalizedUsername,
        Guid? excludeUserId = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Users.AsQueryable( );

        if (excludeUserId.HasValue)
            query = query.Where(u => u.Id != excludeUserId.Value);

        return !await query.AnyAsync(
            u => u.NormalizedUsername == normalizedUsername,
            cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(
        string normalizedEmail,
        Guid? excludeUserId = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Users.AsQueryable( );

        if (excludeUserId.HasValue)
            query = query.Where(u => u.Id != excludeUserId.Value);

        return !await query.AnyAsync(
            u => u.NormalizedEmail == normalizedEmail,
            cancellationToken);
    }
}
