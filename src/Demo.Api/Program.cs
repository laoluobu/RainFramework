using Demo.Api;
using Microsoft.EntityFrameworkCore;
using RainFramework.AspNetCore;
using RainFramework.Dao;
using RainFramework.Dao.PomeloMysql;
using RainFramework.Preconfigured.Configurer;
using RainFramework.Preconfigured.Filters;
using RainFramework.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.AddHttpResponseFilter())
                .AddNewtonsoftJsonConfig();

var dbConnectString = builder.Configuration.GetConnectionString("MySql");
var redisConnectionString = builder.Configuration.GetConnectionString("Redis");

builder.Services.AddRFPomeloMysql<WMSDBContext>(dbConnectString);
builder.Services.AddRedis(redisConnectionString!);

var app = builder.UseRainFrameworkCore<WMSDBContext>(Serilog.Events.LogEventLevel.Information);

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var scopeServices = scope.ServiceProvider;
    var wMSDBContext = scopeServices.GetRequiredService<WMSDBContext>();
    var loggerFactory = scopeServices.GetRequiredService<ILoggerFactory>();
    await RFDBContextSeed.SeedAsync(wMSDBContext, loggerFactory.CreateLogger<WMSDBContext>(), 1);
}
await app.RunAsync();
