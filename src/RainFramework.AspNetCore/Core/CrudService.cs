using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RainFramework.AspNetCore.Core
{   
    internal class CrudService
    {
        private DbContext dbContext;

        public CrudService(DbContext dbContext) {
        
        
        }


        public void update<TEntity>(TEntity entity) where TEntity : class
        {

            dbContext.Update<TEntity>(entity);
        }
    }
}
