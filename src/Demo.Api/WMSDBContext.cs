using Microsoft.EntityFrameworkCore;
using RainFramework.Repository.DBContext;

namespace Demo.Api
{
    public class WMSDBContext : RFDBContext
    {
        public WMSDBContext(DbContextOptions<WMSDBContext> options) : base(options)
        {
        }
    }
}