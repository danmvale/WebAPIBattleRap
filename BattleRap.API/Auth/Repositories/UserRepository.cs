using BattleRap.API.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleRap.API.Auth.Repositories
{
    public class UserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetAsync(string username, string password) => await _context.Set<User>()
            .FirstOrDefaultAsync(x => x.Username.Equals(username)
                 && x.Password.Equals(password));

        public async Task<User?> AddAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
