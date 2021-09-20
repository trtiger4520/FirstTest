using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace FirstTest.WebServer.ServicesExtensions
{
    public static class SwaggerDoc
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo systemVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            services.AddOpenApiDocument(option => {
                option.Title = "First Test System Solution";
                option.Version = systemVersionInfo.FileVersion;
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();

            return app;
        }
    }
}