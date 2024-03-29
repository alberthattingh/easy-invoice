﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Helpers;
using BusinessLogic.Services;
using EasyInvoice.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Models;

namespace EasyInvoice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService UserService;
        private readonly AppSettings AppSettings;

        public UsersController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            UserService = userService;
            AppSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public ActionResult<UserDTO> Authenticate([FromBody] LoginDTO loginModel)
        {
            var user = UserService.Authenticate(loginModel.Email, loginModel.Password);

            if (user == null)
                return BadRequest("Email or password is incorrect.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.JwtToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            UserDTO userDto = new UserDTO(user) { Token = tokenString };

            return Ok(userDto);
        }

        [HttpGet]
        public ActionResult<IList<UserDTO>> GetAllUsers()
        {
            var users = UserService.GetAllUsers();

            IList<UserDTO> userDtos = new List<UserDTO>();
            foreach (var entity in users)
            {
                userDtos.Add(new UserDTO(entity));
            }

            return Ok(userDtos);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDTO> RegisterNewUser([FromBody] User user)
        {
            if (user.FirstName == null || user.LastName == null || user.UserPassword == null)
                return BadRequest("One or more required fields were not supplied.");

            User createdUser = UserService.CreateNewUser(user);
            return Ok(new UserDTO(createdUser));
        }

        [HttpPut]
        public ActionResult<UserDTO> UpdateUserDetails([FromBody] User user)
        {
            string userId = User?.Identity?.Name;
            if (userId == null) return BadRequest("An error occurred. The user could not be updated.");

            User updated = UserService.UpdateUserDetails(user, int.Parse(userId));
            return Ok(new UserDTO(updated));
        }

        [HttpDelete]
        public ActionResult DeleteUser()
        {
            string userId = User?.Identity?.Name;
            if (userId == null) return BadRequest("An error occurred. The user could not be deleted.");

            UserService.DeleteUserById(int.Parse(userId));
            return Ok();
        }

        [HttpPost("Logo")]
        public async Task<ActionResult<UserDTO>> UpdateUserLogo([FromForm] LogoDTO logo)
        {
            string userId = User?.Identity?.Name;
            if (userId == null) return BadRequest("An error occurred. The logo could not be updated.");

            User updated = await UserService.UpdateUserLogo(logo.File, int.Parse(userId));
            return Ok(new UserDTO(updated));
        }

        [HttpGet("Logo")]
        public async Task<ActionResult> GetLogo()
        {
            string userId = User?.Identity?.Name;
            if (userId == null) return BadRequest("An error occurred. The user could not be authenticated.");

            var path = await UserService.GetUserLogo(int.Parse(userId));
            var mimeType = $"image/{Path.GetExtension(path).Replace(".", "")}";
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 4096,
                FileOptions.DeleteOnClose);

            return File(fileStream,
                mimeType,
                Path.GetFileName(path)
            );
        }
    }
}