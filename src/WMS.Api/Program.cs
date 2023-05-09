using Serilog;
using WMS.Api.Configurer;
using WMS.Api.JWT;
using WMS.Mysql.Repository;

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

            builder.Services.AddSingleton<IJWTService, JWTService>();

            builder.Services.AddJwtBearerPkg();

            builder.Services.AddMySQLDbPool(builder.Configuration.GetConnectionString("Mysql"));

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
                           .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
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