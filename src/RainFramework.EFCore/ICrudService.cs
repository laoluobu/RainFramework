using System.Linq.Expressions;
using RainFramework.Entities.Abstractions;

namespace RainFramework.EFCore
{
    public interface ICrudService<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// 批量创建实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
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
        Task<TEntity> FirstAsync(int key);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);

        ///
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        
        Task<TEntity?> FirstOrDefaultAsync(int key);
        
        Task RemoveAsync(TEntity entity);
        
        Task SaveChangesAsync();

        Task UpdatesAsync(TEntity entity);
    }
}