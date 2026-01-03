using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CMS.Infrastructure.Persistence;
using CMS.Application.Auth.Interfaces;
using CMS.Infrastructure.Repositories.Auth;

namespace CMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        #region Register DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        #endregion

        // Repositories
        #region Register Repositories
        services.AddScoped<IUserRepository, UserRepository>( );
        services.AddScoped<IRoleRepository, RoleRepository>( ); // اگر ساختی
        #endregion

        return services;
    }
}