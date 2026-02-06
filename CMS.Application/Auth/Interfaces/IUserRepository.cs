using CMS.Domain.Auth.Entities;

public interface IUserRepository
{
    Task AddAsync( User user );
    Task<User?> GetByEmailAsync( string email );
}
