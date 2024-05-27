using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RainFramework.Common.Configurer
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
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

                var directory = new DirectoryInfo(AppContext.BaseDirectory);
                foreach (var file in directory.GetFiles())
                {
                    if ((file.Name.StartsWith("RainFramework.") && file.Name.EndsWith(".xml")) || file.Name.EndsWith("Api.xml"))
                    {
                        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, file.Name), true);
                    }
                }
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
            return services;
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