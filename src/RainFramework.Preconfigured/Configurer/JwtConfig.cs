using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace RainFramework.Preconfigured.Configurer
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtBearerPkg(this IServiceCollection services)
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

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("111111ssDDDDDD11111111111111asdasdd111111asdasdas")),

                    ValidateAudience = false,
                };
                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = msgContex =>
                    {
                        if (msgContex.Request.Path.HasValue && msgContex.Request.Path.Value.Contains("Hub"))
                        {
                            if (msgContex.Request.Query.ContainsKey("access_token"))
                            {
                                msgContex.Token = msgContex.Request.Query["access_token"];
                            }
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
    }
}
