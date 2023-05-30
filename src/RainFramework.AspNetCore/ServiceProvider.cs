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
        public static void AddRainFrameworkCore(this WebApplicationBuilder builder, out WebApplication application)
        {
            builder.Services.AddMyCors();
            builder.Host.UseSerilogger();
            builder.Services.AddSwagger();
            builder.Services.AddJwtBearerPkg();
            builder.Services.AddSingleton<IJWTService, JWTService>();
            builder.Services.AddBaseDBContext(builder.Configuration.GetConnectionString("MySql"));
            builder.Services.AddTransient<IUserAuthService, UserAuthService>();
            builder.Services.AddTransient<IUserInfoService, UserInfoService>();
            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddTransient<IRoleService, RoleService>();

            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Profile)).ToArray();
            builder.Services.AddAutoMapper(profiles);

            application = builder.Build();
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
        }
    }
}