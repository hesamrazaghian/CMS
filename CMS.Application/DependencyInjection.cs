using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Register MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly( ));
        });
        #endregion

        #region Register AutoMapper with explicit assembly scanning
        services.AddAutoMapper(Assembly.GetExecutingAssembly( ));
        #endregion

        return services;
    }
}