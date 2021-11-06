using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Http;
using Persistence.Models;
using Persistence.Repositories;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository UsersRepository;
        private readonly IHashing Hashing;
        private readonly ICloudStorage CloudStorage;

        public UserService(IUsersRepository usersRepository, IHashing hashing, ICloudStorage cloudStorage)
        {
            UsersRepository = usersRepository;
            Hashing = hashing;
            CloudStorage = cloudStorage;
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

            user.UserId = null;
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

        public void DeleteUserById(int userId)
        {
            UsersRepository.DeleteUserById(userId);
        }

        public User UpdateUserDetails(User user, int userId)
        {
            user.UserId = userId;

            var updated = UsersRepository.UpdateUser(user);
            return updated;
        }

        public async Task<User> UpdateUserLogo(IFormFile logo, int userId)
        {
            var user = GetById(userId);
            var logoUrl = await UploadFile(logo, user);

            user.LogoUrl = logoUrl;
            user.LogoName = user.LogoUrl
                .Split('/')
                .Last()
                .Split('?')
                .First();

            return UsersRepository.UpdateUser(user);
        }

        public async Task<string> GetUserLogo(int userId)
        {
            var user = UsersRepository.GetUserById(userId);

            var path = await CloudStorage.DownloadFileAsync(user.LogoName);
            return path;
        }

        private async Task<string> UploadFile(IFormFile file, User user)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var fileNameForStorage = $"{user.FirstName}{user.LastName}-{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";

            var url = await CloudStorage.UploadFileAsync(file, fileNameForStorage);
            return url;
        }
    }
}