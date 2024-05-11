using RainFramework.EFCore.Base;

namespace RainFramework.Common.Base
{
    public interface ICrudService<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 查找全表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity?>> FindAll();

        /// <summary>
        /// 根据主键查找实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(object key);

        Task RemoveAsync(TEntity entity);

        Task UpdatesAsync(TEntity entity);
    }
}