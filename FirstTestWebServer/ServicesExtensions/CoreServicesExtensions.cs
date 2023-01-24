using FirstTest.Service;
using Mapster;

namespace FirstTest.WebServer.ServicesExtensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {

            services.AddSingleton(provider =>
            {
                var config = new TypeAdapterConfig();

                config.ConfigServicesMapper();

                return config;
            });

            services.AddServices();

            return services;
        }
    }
}
