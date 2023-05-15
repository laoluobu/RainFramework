using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RainFramework.AspNetCore.Configurer;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Repository;
using Serilog;

namespace RainFramework.AspNetCore
{
    public static class ServiceProvider
    {
        public static void AddRainFrameworkCore<T>(this WebApplicationBuilder builder, out WebApplication application)
        {
            builder.Host.UseSerilogger();
            builder.Services.AddSwagger(typeof(T).Assembly.GetName().Name);          
            builder.Services.AddJwtBearerPkg();
            builder.Services.AddSingleton<IJWTService, JWTService>();
            builder.Services.AddBaseDBContext(builder.Configuration.GetConnectionString("MySql"));
            builder.Services.AddTransient<IUserAuthService, UserAuthService>();
            builder.Services.AddTransient<IUserInfoService, UserInfoService>();
            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddTransient<IRoleService, RoleService>();
            builder.Services.AddMyCors();

            application = builder.Build();
            //启用跨域请求
            application.UseCors();
            application.UseSerilogRequestLogging();

            if (application.Environment.IsDevelopment())
            {
                application.UseSwaggerPkg();
            }
            application.UseAuthentication();
            application.UseAuthorization();
        }
    }
}