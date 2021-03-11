using System.Collections.Generic;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
        User CreateNewUser(User user);
        User Authenticate(string email, string password);
        User GetById(int userId);
    }
}