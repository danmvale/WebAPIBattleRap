namespace BattleRap.API.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> GetAsync(int page, int pageSize);
        Task<T?> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T?> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveAsync(int id);
    }
}
