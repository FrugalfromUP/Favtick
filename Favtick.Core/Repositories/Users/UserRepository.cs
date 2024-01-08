using Favtick.Core.Entities;
using Favtick.Core.Entities.Login;
using Favtick.Core.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favtick.Core.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FavtickContext _favtickContext;
        public UserRepository(FavtickContext favtickContext)
        {
            _favtickContext = favtickContext;
        }
        public async Task<User> Get(int id)
        {
            var data = await _favtickContext.Users.FirstOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
            return data;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var data = await _favtickContext.Users.ToListAsync().ConfigureAwait(false);
            return data;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _favtickContext.Users.FirstOrDefaultAsync(user => user.UserName == userName).ConfigureAwait(false);
            return user;
        }
        public async Task<User> Create(User user)
        {
            await _favtickContext.AddAsync(user).ConfigureAwait(false);
            await _favtickContext.SaveChangesAsync();
            return user;
        }

        public User Update(User user)
        {
            _favtickContext.Users.Update(user);
            //await _favtickContext.SaveChangesAsync().ConfigureAwait(false);
            return user;
        }

    }
}
