using System.Linq.Expressions;
using RainFramework.Entities.Abstractions;

namespace RainFramework.EFCore
{
    public interface ICrudService<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> AnyAsync();

        /// <summary>
        /// 查找全表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity?>> FindAllAsync();

        /// <summary>
        /// 根据主键查找实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(object key);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FirstOrDefaultAsync(int key);
        Task RemoveAsync(TEntity entity);
        Task SaveChangesAsync();
        Task UpdatesAsync(TEntity entity);
    }
}