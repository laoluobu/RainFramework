using RainFramework.AspNetCore;

namespace Demo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.AddRainFrameworkCore<Program>(out WebApplication app);

            app.MapControllers();

            app.Run();
        }
    }
}