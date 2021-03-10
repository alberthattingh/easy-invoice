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
    }
}