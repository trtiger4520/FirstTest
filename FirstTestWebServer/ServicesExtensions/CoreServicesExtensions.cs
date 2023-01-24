using FirstTest.Service;
using Mapster;
using MapsterMapper;

namespace FirstTest.WebServer.ServicesExtensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();

            config.ConfigServicesMapper();
            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();

            services.AddServices();

            return services;
        }
    }
}
