using CMS.Domain.Auth.Entities;
using MediatR;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler( IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken )
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User(
            request.Username,
            request.Email,
            passwordHash);

        await _userRepository.AddAsync( user );

        return user.Id;
    }
}
