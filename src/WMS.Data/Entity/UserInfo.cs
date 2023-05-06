using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Data.Entity
{
    public class UserInfo:EntityBase
    {
        public int Id { get; private set; }

        public string? Email { get; set; }

        public string? Nickname { get; set; }

        public bool IsDisable { get; set; }
    }
}
