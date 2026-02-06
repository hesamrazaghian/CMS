

namespace CMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builder
            var builder = WebApplication.CreateBuilder(args);
            #endregion

            #region Services // register application & infrastructure services

            // Add controllers (API)
            builder.Services.AddControllers( );

            //// Register Application Layer (CQRS, Mediator, Mapper, Validation)
            //builder.Services.AddApplication( );

            //// Register Infrastructure Layer (DbContext, Auth, Persistence)
            //builder.Services.AddInfrastructure(builder.Configuration);

            // Register OpenAPI / Swagger
            builder.Services.AddOpenApi( );

            #endregion

            #region Build
            var app = builder.Build( );
            #endregion

            #region Middleware // configure HTTP pipeline

            // Enable Swagger UI in development
            if (app.Environment.IsDevelopment( ))
            {
                app.MapOpenApi( );
            }

            // Redirect HTTP → HTTPS
            app.UseHttpsRedirection( );

            // Authorization middleware
            app.UseAuthorization( );

            // Map API controllers
            app.MapControllers( );

            #endregion

            #region Run
            app.Run( );
            #endregion
        }
    }
}
