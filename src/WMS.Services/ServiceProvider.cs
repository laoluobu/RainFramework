using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WMS.Api.JWT;
using WMS.Repository.WMSDB;
using WMS.Services.Core.Auth;

namespace WMS.Services
{
    public static class ServiceProvider
    {
        public static void AddMySQLDbPool(this IServiceCollection services, string DbConnectString)
        {
            if (string.IsNullOrEmpty(DbConnectString))
            {
                throw new ArgumentNullException(nameof(DbConnectString));
            }

            services.AddDbContextPool<WMSDBContext>(options =>
            {
                options.UseMySql(DbConnectString, ServerVersion.Parse("8.0.33-mysql"),
                   optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                    maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                       errorNumbersToAdd: null));
            });
        }

        private static void AddJwtBearerPkg(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                //将默认Cookie认证改为JWT
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("11111111111111111111111111")),

                    ValidateAudience = false,
                };
                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = msgContex =>
                    {
                        if (msgContex.Request.Query.ContainsKey("access_token"))
                        {
                            msgContex.Token = msgContex.Request.Query["access_token"];
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddSingleton<IJWTService, JWTService>();
        }

        public static void AddWMSCore(this IServiceCollection services)
        {
            services.AddJwtBearerPkg();
            services.AddTransient<IUserAuthServices, UserAuthServices>();
        }
    }
}