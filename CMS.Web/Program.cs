using CMS.Application;
using CMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ================================
// 1️⃣ Web API
// ================================

builder.Services.AddControllers( );

// ================================
// 2️⃣ Application & Infrastructure
// ================================

// Application layer (MediatR, Validation, AutoMapper)
builder.Services.AddApplicationServices( );

// Infrastructure layer (EF Core, DbContext, Repositories)
builder.Services.AddInfrastructureServices( builder.Configuration );

// ================================
// 3️⃣ OpenAPI
// ================================

builder.Services.AddOpenApi( );

var app = builder.Build();

// ================================
// 4️⃣ HTTP Pipeline
// ================================

if( app.Environment.IsDevelopment( ) )
{
    app.MapOpenApi( );
}

app.UseHttpsRedirection( );

app.UseAuthorization( );

app.MapControllers( );

app.Run( );
