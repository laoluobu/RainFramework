using Microsoft.EntityFrameworkCore;
using RainFramework.Efcore.Exceptions;
using RainFramework.EFCore.Base;

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

        public async Task UpdatesAsync(TEntity entity)
        {
            dbSet.Update(entity);
            if (await dbContext.SaveChangesAsync() < 1)
            {
                throw new EntityUpdateException($"The {entity} Update error!");
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            if (await dbContext.SaveChangesAsync() < 1)
            {
                throw new EntityUpdateException($"The {entity} insert error!");
            }
        }

        public async Task RemoveAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(object key)
        {
            var entity = await dbSet.FindAsync(key);
            if (entity == null)
            {
                throw new NotFoundException($"The Entity id is {key} inexistence!");
            }
            return entity;
        }

        public async Task<IEnumerable<TEntity?>> FindAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
    }

}