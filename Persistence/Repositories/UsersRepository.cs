using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DbContext Context;

        public UsersRepository(DbContext context)
        {
            Context = context;
        }

        public IList<User> GetAllUsers()
        {
            var users = Context.Set<User>();

            return users.ToList();
        }

        public User CreateNewUser(User user)
        {
            Context.Set<User>().Add(user);
            Context.SaveChanges();

            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User GetUserById(int userId)
        {
            var user = Context.Set<User>().FirstOrDefault(u => u.UserId == userId);
            return user;
        }
    }
}