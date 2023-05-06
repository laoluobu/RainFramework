using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Data.Entity
{
    public class EntityBase
    {
        public DateTime? CreateTime { get; private set; }

        public DateTime? UpdateTime { get; private set; }
    }
}
