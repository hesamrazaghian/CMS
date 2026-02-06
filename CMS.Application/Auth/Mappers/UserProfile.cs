using AutoMapper;
using CMS.Domain.Auth.Entities;

public class UserProfile : Profile
{
    public UserProfile( )
    {
        CreateMap<User, UserDto>( );
    }
}
