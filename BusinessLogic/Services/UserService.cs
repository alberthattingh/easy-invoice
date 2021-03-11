using System.Collections.Generic;
using BusinessLogic.Exceptions;
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

        public User CreateNewUser(User user)
        {
            if (user.Email == null || UsersRepository.GetUserByEmail(user.Email) != null)
            {
                throw new InvalidEmailException(user.Email);
            }

            user.UserPassword = Hashing.HashPassword(user.UserPassword);
            return UsersRepository.CreateNewUser(user);
        }

        public User Authenticate(string email, string password)
        {
            var user = UsersRepository.GetUserByEmail(email);

            if (user == null) return null;

            if (Hashing.ValidatePassword(password, user.UserPassword))
            {
                return user;
            }

            return null;
        }

        public User GetById(int userId)
        {
            return UsersRepository.GetUserById(userId);
        }
    }
}