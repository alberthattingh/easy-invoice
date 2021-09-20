using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
        User CreateNewUser(User user);
        User Authenticate(string email, string password);
        User GetById(int userId);
        void DeleteUserById(int userId);
        Task<User> UpdateUserDetails(User user, int userId);
        Task<string> GetUserLogo(int userId);
    }
}