using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Cahce;
using RainFramework.Dao;
using RainFramework.Preconfigured.Configurer;
using Serilog.Events;

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
                            .AddScoped<IUserAuthService, UserAuthService<TDbContext>>()
                            .AddScoped<IUserInfoService, UserInfoService<TDbContext>>()
                            .AddScoped<IMenuService, MenuService<TDbContext>>()
                            .AddScoped<IRoleService, RoleService<TDbContext>>()
                            .AddRFMemoryCache(builder.Configuration.GetSection("RFMemoryCache").Get<RFCacheOption>()!)
                            .AddResourceMonitoring()
                            .AddAutoMapper(profiles);

            var application = builder.Build();
            //启用跨域请求
            application.UseCors();
            application.UseHttpRequestLogging();

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