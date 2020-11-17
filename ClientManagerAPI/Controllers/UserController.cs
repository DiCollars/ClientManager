using ClientManager.Models;
using ClientManager.Services.UserService;
using ClientManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ClientManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("get-all-users")]
        public IEnumerable<UserWithAccounts> GetAll()
        {
            _logger.LogInformation("/api/user/get-all-users - [200]\n");
            
            return _userService.GetAll();
        }

        [Route("get-user-by-id/{userId}")]
        [HttpGet]
        public UserWithAccounts GetUser(int userId)
        {
            _logger.LogInformation($"/api/user/get-user-by-id/{userId} - [200]\n");
            
            return _userService.GetById(userId);
        }

        [HttpPost("add-new-user")]
        public IActionResult AddUser([FromBody]User newUser)
        {
            try
            {
                _userService.Add(newUser);
                _logger.LogInformation($"/api/user/add-new-user - [200]\n{{\n\tId: {newUser.Id}\n\tName: {newUser.Name}\n\tLast name: {newUser.LastName}\n\tEmail: {newUser.Email}\n}}\n");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"/api/user/add-new-user - [400] ({ex.Message})\n{{\n\tId: {newUser.Id}\n\tName: {newUser.Name}\n\tLast name: {newUser.LastName}\n\tEmail: {newUser.Email}\n}}\n");
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody]User user)
        {
            try
            {
                _userService.Update(user);
                _logger.LogInformation($"/api/user/update-user - [200]\n{{\n\tId: {user.Id}\n\tName: {user.Name}\n\tLast name: {user.LastName}\n\tEmail: {user.Email}\n}}\n");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"/api/user/update-user - [400] ({ex.Message})\n{{\n\tId: {user.Id}\n\tName: {user.Name}\n\tLast name: {user.LastName}\n\tEmail: {user.Email}\n}}\n");
                
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-user-by-id/{userId}")]
        [HttpDelete]
        public IActionResult RemoveUser(int userId)
        {
            try
            {
                _userService.Remove(userId);
                _logger.LogInformation($"/api/user/delete-user-by-id/{userId} - [200]\n");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"/api/user/delete-user-by-id/{userId} - [400] ({ex.Message})\n");

                return BadRequest(ex.Message);
            }
        }
    }
}
