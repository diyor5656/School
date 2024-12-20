using Microsoft.EntityFrameworkCore;
using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class UserRepository : BaseRepository<User>, IUserRepository
{
  
    
        public UserRepository(DatabaseContext context) : base(context) { }

        // Username bo'yicha foydalanuvchini olish
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await DbSet.FirstOrDefaultAsync(u => u.UserName == username);
        }

        // ID bo'yicha foydalanuvchini olish
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(u => u.Id == id);
        }
    
}


