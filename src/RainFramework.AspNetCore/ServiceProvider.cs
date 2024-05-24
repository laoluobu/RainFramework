using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Cahce;
using RainFramework.Common.Configurer;
using RainFramework.Repository;
using RainFramework.Repository.DBContext;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Security.Claims;

namespace RainFramework.AspNetCore
{
    public static class ServiceProvider
    {
        public static WebApplication UseRainFrameworkCore<TDbContext> (this WebApplicationBuilder builder, LogEventLevel httpRequestLogL, params Type[] profileAssemblyMarkerTypes) where TDbContext : RFDBContext
        {
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Profile)).ToArray();

            if (profiles.Any())
            {
                profiles = profiles.Concat(profileAssemblyMarkerTypes).ToArray();
            }

#if DEBUG
            var profileNames = profiles.Select(profile => profile.Name).ToArray();
            Console.WriteLine($"[AutoMapper] FindProfile: {string.Join(",", profileNames)}");
#endif
            builder.Services.AddMyCors();
            builder.Host.UseSerilogger();

            builder.Services.AddSwagger()

                            .AddJwtBearerPkg()
                            .AddSingleton<IJWTService, JWTService>()
                            //.AddBaseDBContext(builder.Configuration.GetConnectionString("MySql")!, builder.Configuration["Mysql.Version"])
                            .AddTransient<IUserAuthService, UserAuthService<TDbContext>>()
                            .AddTransient<IUserInfoService, UserInfoService<TDbContext>>()
                            .AddTransient<IMenuService, MenuService<TDbContext>>()
                            .AddTransient<IRoleService, RoleService<TDbContext>>()
                            .AddRFMemoryCache(builder.Configuration.GetSection("RFMemoryCache").Get<RFCacheOption>()!)
                            .AddAutoMapper(profiles);

            var application = builder.Build();
            //启用跨域请求
            application.UseCors();
            application.UseSerilogRequestLogging(option =>
             {
                 option.MessageTemplate = "[ApiOperate] User {UserName} ClientIp {ClientIp} " + option.MessageTemplate;

                 option.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Information;

                 option.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                 {
                     diagnosticContext.Set("UserName", httpContext.User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value ?? "None");
                     diagnosticContext.Set("ClientIp", httpContext.Connection.RemoteIpAddress?.MapToIPv4());
                 };
             });

            if (application.Environment.IsDevelopment())
            {
                application.UseSwaggerPkg();
            }
            application.UseAuthentication();
            application.UseAuthorization();
            application.MapControllers();

            return application;
        }
    }
}