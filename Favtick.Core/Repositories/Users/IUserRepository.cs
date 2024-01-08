using Favtick.Core.Entities.Login;

namespace Favtick.Core.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserByUserName(string userName);
        User Update(User user);
    }
}