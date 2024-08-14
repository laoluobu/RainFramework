using Demo.Api;
using Microsoft.EntityFrameworkCore;
using RainFramework.AspNetCore;
using RainFramework.Dao;
using RainFramework.Preconfigured.Filters;
using RainFramework.Preconfigured.Configurer;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.AddHttpResponseFilter())
                .AddNewtonsoftJsonConfig();

var dbConnectString = builder.Configuration.GetConnectionString("MySql");

var version = ServerVersion.AutoDetect(dbConnectString);
builder.Services.AddDbContextPool<WMSDBContext>(options =>
{
    options.UseMySql(dbConnectString, version,
       optionsBuilder => optionsBuilder.EnableRetryOnFailure(
        maxRetryCount: 5,
        maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null)
        .UseNewtonsoftJson()
        );
    //´òÓ¡sql²ÎÊý
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

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
