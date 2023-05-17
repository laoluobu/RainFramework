using Microsoft.EntityFrameworkCore;

namespace RainFramework.Common.Base
{
    public class CrudService<TDbContext, TEntity> : ICrudService<TEntity> where TDbContext : DbContext where TEntity : EntityBase
    {
        protected TDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public CrudService(TDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task<bool> UpdatesAsync(TEntity entity)
        {
            dbSet.Update(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<TEntity?> FindAsync(object key)
        {
            return await dbSet.FindAsync(key);
        }

        public async Task<IEnumerable<TEntity?>> FindAll()
        {
            return await dbSet.ToListAsync();
        }
    }
}