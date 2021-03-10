using System.Collections.Generic;
using Persistence.Models;
using Persistence.Repositories;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository UsersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            UsersRepository = usersRepository;
        }

        public IList<User> GetAllUsers()
        {
            return UsersRepository.GetAllUsers();
        }
    }
}