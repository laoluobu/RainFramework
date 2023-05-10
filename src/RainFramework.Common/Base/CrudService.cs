using Microsoft.EntityFrameworkCore;

namespace RainFramework.Common.Base
{
    public class CrudService<TDbContext, TEntity> : ICrudService<TEntity> where TDbContext : DbContext where TEntity : class
    {
        private TDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;


        public CrudService(TDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task<bool> UpdatesAsync(TEntity entity)
        {
            dbContext.Update(entity);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await dbContext.AddAsync(entity);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            dbContext.Remove(entity);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<TEntity?> FindAsync(object key)
        {
            return await dbSet.FindAsync(key);
        }
    }
}