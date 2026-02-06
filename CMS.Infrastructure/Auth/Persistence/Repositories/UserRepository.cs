using CMS.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Auth.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository( AppDbContext context )
    {
        _context = context;
    }

    public async Task AddAsync( User user, CancellationToken cancellationToken )
    {
        _context.Users.Add( user );
        await _context.SaveChangesAsync( cancellationToken );
    }

    public Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken )
    {
        return _context.Users
            .FirstOrDefaultAsync( x => x.Email == email, cancellationToken );
    }
}
