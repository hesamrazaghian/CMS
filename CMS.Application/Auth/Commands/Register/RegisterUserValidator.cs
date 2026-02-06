using FluentValidation;

public class RegisterUserValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator( )
    {
        RuleFor( x => x.Username )
            .NotEmpty( )
            .Length( 3, 50 );

        RuleFor( x => x.Email )
            .NotEmpty( )
            .EmailAddress( );

        RuleFor( x => x.Password )
            .MinimumLength( 8 );
    }
}
