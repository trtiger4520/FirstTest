using FirstTest.Database.FirstTestDB;
using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.ServicesExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(Log.Logger);

builder.Services.Configure<SystemConfig>(
    builder.Configuration.GetSection(SystemConfig.Name));

builder.Services.AddDbContext<TestDBContext>(option =>
    option.UseInMemoryDatabase("TestDB"));

builder.Services.AddCoreServices();

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        builder.Configuration.GetSection("JwtSettings").Bind(options);
    });

builder.Services.AddControllers();

builder.Services.AddApiVersioning(option =>
{
    option.ReportApiVersions = true;
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddSwaggerDoc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseHsts();

app.UseSwaggerDoc();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "���ε{���o���Y�����~�A�w�ߧY����I");
}
finally
{
    Log.CloseAndFlush();
}
