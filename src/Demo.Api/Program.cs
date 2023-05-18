using RainFramework.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
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
                //使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.UseCamelCasing(false);
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //日期类型默认格式化处理
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                options.SerializerSettings.Culture = CultureInfo.GetCultureInfo("zh-cn");
                //空值处理
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            builder.AddRainFrameworkCore(out WebApplication app);
            app.MapControllers();

            app.Run();
        }
    }
}