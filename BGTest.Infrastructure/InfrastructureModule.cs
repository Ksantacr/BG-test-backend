using BGTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BGTest.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddDatabaseDependency()
            .AddAuthDependencies()
            .AddServiceDependencies();
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

        return serviceCollection;
    }

    public static IServiceCollection AddServiceDependencies(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}