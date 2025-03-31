using System.Net.Sockets;
using System.Text;
using BGTest.Core.Repositories;
using BGTest.Infrastructure.Data;
using BGTest.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace BGTest.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddDatabaseDependency()
            .AddAuthDependencies()
            .AddLoggingInfrastructure()
            .AddCustomCors()
            .AddServiceDependencies();
    }

    public static IServiceCollection AddLoggingInfrastructure(this IServiceCollection serviceCollection)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        serviceCollection.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders(); // Remove default logging providers
            loggingBuilder.AddSerilog(); // Add Serilog as the logging provider
        });

        return serviceCollection;
        
    }
    public static IServiceCollection AddCustomCors(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddCors(options =>
        {
            options.AddPolicy("all", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            // options.AddPolicy("AllowLocalhost",
            //     policy => policy.WithOrigins("http://localhost:4200")
            //         .AllowAnyMethod()
            //         .AllowAnyHeader()
            //         .AllowCredentials()
            //     ); 
        });
    }

    public static IServiceCollection AddDatabaseDependency(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddDbContextPool<ApplicationDbContext>(
            options =>
            {
                options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION"));
            });
    }

    public static IServiceCollection AddAuthDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("JWTISSUER"),
                    ValidAudience = Environment.GetEnvironmentVariable("JWTAUDIENCE"),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            Environment.GetEnvironmentVariable("JWTKEY") ?? string.Empty))
                });

        return serviceCollection;
    }

    public static IServiceCollection AddServiceDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        return serviceCollection;
    }
}