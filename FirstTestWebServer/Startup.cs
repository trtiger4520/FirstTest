using FirstTest.Core.Account;
using FirstTest.Database.FirstTestDB;
using FirstTest.Service;
using FirstTest.Service.Account;
using FirstTest.WebServer.Model;
using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.ServicesExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace FirstTest.WebServer
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SystemConfig>(
                Configuration.GetSection(SystemConfig.Name));

            services.AddDbContext<TestDBContext>(option =>
                option.UseInMemoryDatabase("TestDB"));

            services.AddAutoMapper(config => {
                config.AddProfile(new Map());
            });

            services.AddScoped<IUserService, UserService>();

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<TestDBContext>();

            //services.AddIdentityServer()
            //    .AddInMemoryCaching()
            //    .AddApiAuthorization<AppUser, TestDBContext>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();


            services.AddControllers();
            services.AddSwaggerDoc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
