using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RainFramework.AspNetCore;
using RainFramework.Common.Filters;

namespace Demo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
            builder.AddRainFrameworkCore().Run();
        }
    }
}