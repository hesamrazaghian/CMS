using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices( this IServiceCollection services )
    {
        // Current Application assembly
        Assembly assembly = typeof(DependencyInjection).Assembly;

        // 1️⃣ MediatR (Commands / Queries / Handlers)
        services.AddMediatR( cfg =>
            cfg.RegisterServicesFromAssembly( assembly ) );

        // 2️⃣ FluentValidation (Command Validators)
        services.AddValidatorsFromAssembly( assembly );

        // 3️⃣ AutoMapper (Entity <-> DTO Mappers)
        services.AddAutoMapper( assembly );

        return services;
    }
}
