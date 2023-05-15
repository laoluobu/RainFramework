using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RainFramework.AspNetCore.Configurer
{
    public static class SwaggerConfig
    {
        public static void AddSwagger(this IServiceCollection services, string? programName)
        {
            services.AddSwaggerGen(options =>
            {
                var apiGroup = new ApiGroup();
                foreach (var field in typeof(ApiGroup).GetFields())
                {
                    options.SwaggerDoc(field.Name, new OpenApiInfo
                    {
                        Version = "v1",
                        Title = field.GetValue(apiGroup)?.ToString(),
                    });
                }
                if (programName != null)
                {
                    var filePath = Path.Combine(AppContext.BaseDirectory, $"{programName}.xml");
                    options.IncludeXmlComments(filePath, true);
                }
           
                var BasePath = Path.Combine(AppContext.BaseDirectory, "RainFramework.AspNetCore.xml");
                options.IncludeXmlComments(BasePath, true);

                //增加JWT Header
                var scheme = new OpenApiSecurityScheme()
                {
                    Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Authorization"
                    },
                    Scheme = "oauth2",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                };
                options.AddSecurityDefinition("Authorization", scheme);
                var requirement = new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                };
                options.AddSecurityRequirement(requirement);
            });
        }

        public static void UseSwaggerPkg(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var field in typeof(ApiGroup).GetFields())
                {
                    options.SwaggerEndpoint($"/swagger/{field.Name}/swagger.json", field.Name);
                }
            });
        }
    }
}