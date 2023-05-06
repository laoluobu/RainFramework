using Microsoft.EntityFrameworkCore;
using WMS.Data.Entity;

namespace WMS.MySQL.Repository
{
    public class WMSDB : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }

        public WMSDB(DbContextOptions<WMSDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                 .Property(o => o.CreateTime).HasDefaultValue(DateTime.Now);

        }

    }
}