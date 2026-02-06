using CMS.Application.Auth.Commands.Register;
using CMS.Application.Auth.Interfaces;
using CMS.Domain.Auth.Entities;
using MediatR;

namespace CMS.Application.Auth.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler( IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle( RegisterUserCommand request, CancellationToken cancellationToken )
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync( user, cancellationToken );

        return user.Id;
    }
}
