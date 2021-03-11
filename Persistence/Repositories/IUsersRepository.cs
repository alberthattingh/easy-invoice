using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IUsersRepository
    {
        IList<User> GetAllUsers();
        User CreateNewUser(User user);
        User GetUserByEmail(string email);
        User GetUserById(int userId);
        void DeleteUserById(int userId);
    }
}