using BattleRap.API.Context;
using BattleRap.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BattleRap.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T?> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<T>> GetAsync(int page, int pageSize) => _context.Set<T>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        public async Task<T?> GetByIdAsync(int id) => await _context.FindAsync<T>(id);

        public async Task<IQueryable<T>> GetAllAsync() => _context.Set<T>();

        public async Task<T?> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            else
            {
                throw new ArgumentOutOfRangeException("Objeto não encontrado.");
            }
        }

        public async Task<bool> RemoveAsync(int id) => await RemoveAsync(await GetByIdAsync(id));
    }
}
