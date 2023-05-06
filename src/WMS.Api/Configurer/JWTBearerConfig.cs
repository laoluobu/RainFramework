using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WMS.Api.Configurer
{
    internal static class JWTBearerConfig
    {
        public static void AddJwtBearerPkg(this IServiceCollection services)
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
        }
    }
}