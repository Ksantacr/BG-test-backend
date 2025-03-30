using BGTest.Application.Services.Products;
using BGTest.Application.Services.TokenHandler;
using BGTest.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace BGTest.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddAplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped<IProductService, ProductService>();

        return serviceCollection;
    }
}