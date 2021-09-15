using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.Exceptions;
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
            var user = Context.Set<User>()
                .Include(u => u.AccountDetails)
                .FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User GetUserById(int userId)
        {
            var user = Context.Set<User>()
                .Include(u => u.AccountDetails)
                .FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public void DeleteUserById(int userId)
        {
            var user = GetUserById(userId);
            
            Context.Set<User>().Remove(user);
            Context.SaveChanges();
        }

        public User UpdateUser(User updatedUser)
        {
            if (updatedUser.UserId == default) throw new UserNotFoundException();
            var user = GetUserById((int) updatedUser.UserId);
            
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Cell = updatedUser.Cell;
            user.Email = updatedUser.Email;
            user.Logo = updatedUser.Logo;
            user.DefaultFee = updatedUser.DefaultFee;

            if (updatedUser.AccountDetails != null && updatedUser.AccountDetails.Any())
            {
                if (user.AccountDetails == null)
                {
                    user.AccountDetails = updatedUser.AccountDetails;
                }
                else
                {
                    foreach (var account in user.AccountDetails)
                        account.IsActive = false;
                    
                    user.AccountDetails.Add(updatedUser.AccountDetails.First());
                }
            }

            Context.Set<User>().Update(user);
            Context.SaveChanges();

            return user;
        }
    }
}