using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainFramework.Common.Base
{
    public interface ICrudService<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity);
        Task<TEntity?> FindAsync(object key);
        Task<bool> RemoveAsync(TEntity entity);
        Task<bool> UpdatesAsync(TEntity entity);
    }
}
