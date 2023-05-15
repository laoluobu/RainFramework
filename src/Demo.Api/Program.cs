using Microsoft.EntityFrameworkCore;
using RainFramework.AspNetCore;
using RainFramework.Repository;
using RainFramework.Repository.DBContext;
using static RainFramework.Repository.DBContext.BaseDBContext;

namespace Demo.Api
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