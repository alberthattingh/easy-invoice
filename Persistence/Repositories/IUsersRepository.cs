using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IUsersRepository
    {
        IList<User> GetAllUsers();
    }
}