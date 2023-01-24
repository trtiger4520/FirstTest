using FirstTest.Service.Account;
using Microsoft.Extensions.DependencyInjection;

namespace FirstTest.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
    
}
