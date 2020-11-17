using ClientManager.Models;
using ClientManager.Services.AccountService;
using ClientManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ClientManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("add-new-account")]
        public IActionResult CreateAccount([FromBody]Account newAccount)
        {
            try
            {
                _accountService.CreateAccount(newAccount);
                _logger.LogInformation($"/api/account/add-new-account [200]\n{{\n\tId: {newAccount.Id}\n\tName: {newAccount.Name}\n\tScore: {newAccount.Score}\n\tUser id: {newAccount.UserId}\n}}\n");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"/api/account/add-new-account [400] ({ex.Message})\n{{\n\tId: {newAccount.Id}\n\tName: {newAccount.Name}\n\tScore: {newAccount.Score}\n\tUser id: {newAccount.UserId}\n}}\n");
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("plus-or-minus-account")]
        public IActionResult UpdateAccount([FromBody]AccountHandler accountHandler)
        {
            try
            {
                _accountService.UpdateAccount(accountHandler.AccountId, accountHandler.Operation, accountHandler.Sum);
                _logger.LogInformation($"/api/account/plus-or-minus-account [200]\n{{\n\tAccount id: {accountHandler.AccountId}\n\tSum: {accountHandler.Sum}\n\tOperation: {accountHandler.Operation}\n}}\n");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"/api/account/plus-or-minus-account [400] ({ex.Message})\n{{\n\tAccount id: {accountHandler.AccountId}\n\tSum: {accountHandler.Sum}\n\tOperation: {accountHandler.Operation}\n}}\n");
                
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-account-by-id/{accountId}")]
        [HttpDelete]
        public IActionResult RemoveAccount(int accountId)
        {
            try
            {
                _accountService.Remove(accountId);
                _logger.LogInformation($"/api/account/delete-account-by-id/{accountId} [200]");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"/api/account/delete-account-by-id/{accountId} [400] ({ex.Message})");
                
                return BadRequest(ex.Message);
            }
        }
    }
}