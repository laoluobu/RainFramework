using Microsoft.EntityFrameworkCore;
using RainFramework.Dao;

namespace Demo.Api
{
    public class WMSDBContext : RFDBContext
    {
        public WMSDBContext(DbContextOptions<WMSDBContext> options) : base(options)
        {
        }
    }
}