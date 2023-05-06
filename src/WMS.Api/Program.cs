using Serilog;
using WMS.Api.Configurer;
using WMS.Api.JWT;
using WMS.MySQL.Repository;

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

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerPkg();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<WMSDB>();
                context.Database.EnsureCreated();
                DBinit.Init(context);
            }



            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}