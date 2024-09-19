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
    await WMSDBContextSeed.SeedAsync(app.Services);
}
await app.RunAsync();
