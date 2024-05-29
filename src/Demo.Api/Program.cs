using System.Globalization;
using Demo.Api;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RainFramework.AspNetCore;
using RainFramework.AspNetCore.Filters;
using RainFramework.Dao;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<HttpResponseFilter>())
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.UseCamelCasing(false);
    //����ѭ������
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    options.SerializerSettings.Culture = CultureInfo.GetCultureInfo("zh-cn");
    //��ֵ����
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});

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
    //��ӡsql����
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


app.Run();


