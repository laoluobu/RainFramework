using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Data.Entity;

namespace WMS.MySQL.Repository
{
    public class DBinit
    {
        public static void Init(WMSDB db)
        {
            db.Add(new UserInfo()
            {
                Nickname = "111"
            });
            ;
            db.SaveChanges();
        }
    }
}
