﻿namespace RainFramework.Common.Base
{
    public interface ICrudService<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

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