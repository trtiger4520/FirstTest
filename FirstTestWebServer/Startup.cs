using FirstTest.Database.FirstTestDB;
using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.ServicesExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstTest.WebServer
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SystemConfig>(
                Configuration.GetSection(SystemConfig.Name));
            services.AddDbContext<TestDBContext>(option =>
                option.UseInMemoryDatabase("TestDB"));
            services.AddCoreServices();
            //services.AddJwtAuthorize();
            services.AddAuthentication("jwt")
                .AddScheme<JwtAuthenticationOptions, JwtAuthenticationHandler>("jwt", option => { });
            services.AddControllers();
            services.AddApiVersioning(option => {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddSwaggerDoc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerDoc();

            app.UseRouting();

            //app.UseJwtAuthorize();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
