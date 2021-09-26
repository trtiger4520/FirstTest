using FirstTest.Service;
using FirstTest.Service.Account;
using Microsoft.Extensions.DependencyInjection;

namespace FirstTest.WebServer.ServicesExtensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddAutoMapper(config => {
                config.AddProfile(new Map());
            });

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
