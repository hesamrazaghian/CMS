using CMS.Application.Auth.Interfaces; 
using CMS.Domain.Auth.Entities;
using CMS.Infrastructure.Auth.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Auth.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    public UserRepository( AuthDbContext context )
    {
        _context = context;
    }

    public async Task AddAsync( User user, CancellationToken cancellationToken = default )
    {
        await _context.Users.AddAsync( user, cancellationToken );
        await _context.SaveChangesAsync( cancellationToken );
    }

    public async Task<User?> GetByEmailAsync( string email, CancellationToken cancellationToken = default )
    {
        return await _context.Users
            .FirstOrDefaultAsync( x => x.Email == email, cancellationToken );
    }
}
