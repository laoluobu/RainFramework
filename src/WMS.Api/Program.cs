using Serilog;
using WMS.Api.Configurer;
using WMS.Services;

namespace WMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwagger();

            builder.Services.AddMySQLDbPool(builder.Configuration.GetConnectionString("Mysql"));

            builder.Services.AddWMSCore();

            builder.Host.UseSerilog((context, logging) =>
             {
                 logging.ReadFrom.Configuration(context.Configuration);
                 logging.Enrich.FromLogContext();
             });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                           .SetPreflightMaxAge(TimeSpan.FromHours(5))
                           .AllowAnyHeader().AllowAnyMethod();
                        });
            });

            var app = builder.Build();
            //∆Ù”√øÁ”Ú«Î«Û
            app.UseCors();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerPkg();
            }
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}