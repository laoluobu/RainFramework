using Microsoft.OpenApi.Models;
using WMS.Api.Configurer;

namespace WMS.Api.Config
{
    public static class SwaggerConfig
    {
        public static void AddSwagger(this IServiceCollection services)
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
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml");
                options.IncludeXmlComments(filePath, true);
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