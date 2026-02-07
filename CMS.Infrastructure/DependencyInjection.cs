using CMS.Application.Auth.Interfaces;
using CMS.Infrastructure.Auth.Persistence.Context;
using CMS.Infrastructure.Auth.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration )
    {
        // 1️⃣ Database (EF Core - SQL Server)
        services.AddDbContext<AuthDbContext>( options =>
            options.UseSqlServer(
                configuration.GetConnectionString( "DefaultConnection" ) ) );

        // 2️⃣ Repositories (Infrastructure implementations)
        services.AddScoped<IUserRepository, UserRepository>( );

        return services;
    }
}
