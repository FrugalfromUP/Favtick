using Favtick.Core.Entities.Login;

namespace Favtick.Core.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Get(int id);
        Task<User> GetUserByUserName(string userName);
    }
}