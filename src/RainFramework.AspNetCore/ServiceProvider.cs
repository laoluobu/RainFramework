using System.Reflection;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Repository;
using Serilog;
using Serilog.Events;

namespace RainFramework.AspNetCore
{
    public static class ServiceProvider
    {
        public static WebApplication AddRainFrameworkCore(this WebApplicationBuilder builder, params Type[] profileAssemblyMarkerTypes)
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
                            .AddBaseDBContext(builder.Configuration.GetConnectionString("MySql"))
                            .AddTransient<IUserAuthService, UserAuthService>()
                            .AddTransient<IUserInfoService, UserInfoService>()
                            .AddTransient<IMenuService, MenuService>()
                            .AddTransient<IRoleService, RoleService>()

            .AddAutoMapper(profiles);

            var application = builder.Build();
            //启用跨域请求
            application.UseCors();
            application.UseSerilogRequestLogging(option =>
             {
                 option.MessageTemplate = "User {UserName} ClientIp {ClientIp} " + option.MessageTemplate;

                 option.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

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