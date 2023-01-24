using FirstTest.Database.FirstTestDB;
using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.ServicesExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
builder.Services.AddAuthentication("jwt")
    .AddScheme<JwtAuthenticationOptions, JwtAuthenticationHandler>("jwt", option => { });
builder.Services.AddControllers();
builder.Services.AddApiVersioning(option => {
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
    Log.Fatal(ex, "應用程式發生嚴重錯誤，已立即停止！");
}
finally
{
    Log.CloseAndFlush();
}
