using System.Collections.Generic;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
    }
}