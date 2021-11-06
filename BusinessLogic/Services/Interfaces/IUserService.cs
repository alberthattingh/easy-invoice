using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        User UpdateUserDetails(User user, int userId);
        Task<User> UpdateUserLogo(IFormFile logo, int userId);
        Task<string> GetUserLogo(int userId);
    }
}