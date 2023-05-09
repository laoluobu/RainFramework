using RainFramework.AspNetCore;

namespace WMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.AddWMSCore<Program>(out WebApplication app);

            app.MapControllers();

            app.Run();
        }
    }
}