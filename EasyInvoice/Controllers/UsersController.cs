using System;
using System.Collections.Generic;
using BusinessLogic.Services;
using EasyInvoice.DTOs;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;

namespace EasyInvoice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService)
        {
            UserService = userService;
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

        [HttpPost]
        public ActionResult<UserDTO> CreateNewUser(User user)
        {
            
        }
    }
}