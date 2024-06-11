using System.Diagnostics;
using System.Globalization;
using Demo.Api;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RainFramework.AspNetCore;
using RainFramework.AspNetCore.Filters;
using RainFramework.Dao;
using RainFramework.Helper;



var list = new List<bool>() { false, false, false };
var value1 = list.AllTrue();
var value2 = list.AnyTrue();
Debug.Assert(!(value1 || value2), "AllTrue AnyTrue Error");
var value3 = list.AnyFalse();
var value4 = list.AllFalse();
Debug.Assert(value3 && value4, "AnyFalse AllFalse Error");



var list1 = new List<bool>() { true, true, true };
var value11 = list1.AllTrue();
var value21 = list1.AnyTrue();
Debug.Assert(value11 && value21, "AllTrue AnyTrue Error");
var value31 = list1.AnyFalse();
var value41 = list1.AllFalse();
Debug.Assert(!(value31 || value41), "AnyFalse AllFalse Error");


var list11 = new List<bool>() { false, true, true };
var value111 = list11.AllTrue();
Debug.Assert(!value111, "AllTrue Error");
var value211 = list11.AnyTrue();
Debug.Assert(!value111, "AnyTrue Error");
var value311 = list11.AnyFalse();
Debug.Assert(value311, "AnyFalse Error");
var value411 = list11.AllFalse();
Debug.Assert(!value411, "AllFalse Error");




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<HttpResponseFilter>())
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.UseCamelCasing(false);
    //忽略循环引用
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    options.SerializerSettings.Culture = CultureInfo.GetCultureInfo("zh-cn");
    //空值处理
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
    //打印sql参数
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


