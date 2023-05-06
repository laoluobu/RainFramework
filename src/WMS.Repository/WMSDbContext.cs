using Microsoft.EntityFrameworkCore;

namespace WMS.Mysql.Repository
{
    internal class WMSDB : DbContext
    {
        public WMSDB(DbContextOptions<WMSDB> options) : base(options) { }
    }
}