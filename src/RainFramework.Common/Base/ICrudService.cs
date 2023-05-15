namespace RainFramework.Common.Base
{
    public interface ICrudService<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity?>> FindAll();
        Task<TEntity?> FindAsync(object key);

        Task<int> RemoveAsync(TEntity entity);

        Task<int> UpdatesAsync(TEntity entity);
    }
}