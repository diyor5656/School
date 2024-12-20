using School.Core.Entities;

namespace School.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetByIdAsync(Guid id); 
    }
}
