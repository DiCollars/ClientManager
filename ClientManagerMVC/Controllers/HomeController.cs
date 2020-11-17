using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClientManagerMVC.Models;
using ClientManagerMVC.HttpService.ApiService;
using System.Linq;
using System;
using ClientManagerMVC.JsonModels;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ClientManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ViewModel _viewModel;
        private IConfiguration _configuration;

        public HomeController(IApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _viewModel = new ViewModel();
            _configuration = configuration;
        }

        public IActionResult Main(int? userId, Operation? operation, int? accountId)
        {
            if (operation == Operation.deleteUser && userId != null)
            {
                _apiService.DeleteUser(Convert.ToInt32(userId)).Wait();
            }

            if (operation == Operation.deleteAccount && accountId != null)
            {
                _apiService.DeleteAccount(Convert.ToInt32(accountId)).Wait();
            }

            return Redirect("~/Home/Index"); 
        }

        public IActionResult AddUser(UserJson userJson)
        {
            if (userJson.Name == null && userJson.LastName == null && userJson.Email == null)
            {
                return View();
            }
            else
            {
                _apiService.PostNewUser(userJson).Wait();

                return Redirect("~/Home/Index");
            }
        }

        public IActionResult UpdateUser(int Id, UserJson userJson)
        {
            if (userJson.Name == null && userJson.LastName == null && userJson.Email == null)
            {
                var user = _apiService.GetUser(Id).Result;
                var viewUser = new UserJson()
                {
                    Name = user.FullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First(),
                    LastName = user.FullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last(),
                    Email = user.Email
                };

                return View(viewUser);
            }
            else
            {
                _apiService.PutUser(userJson).Wait();

                return Redirect("~/Home/Index");
            }
        }

        public IActionResult AddScore(int userId, AccountJson account)
        {
            if (account.Name == null)
            {
                ViewBag.Id = userId;

                return View();
            }

            else
            {
                _apiService.PostNewAccount(account).Wait();

                return Redirect("~/Home/Index");
            }
        }

        public IActionResult UpdateAccount(AccountHandlerJson accountHandler, int userId)
        {
            if (accountHandler.Sum == 0)
            {
                ViewBag.Id = accountHandler.AccountId;
                ViewBag.userId = userId;

                return View();
            }

            else
            {
                if (accountHandler.Operation == OperationJson.Decrease)
                {
                    var user = _apiService.GetUser(userId).Result;
                    if (user.Accounts.First(a => a.Id == accountHandler.AccountId).Score - accountHandler.Sum < 0)
                    {
                        return Redirect("~/Home/Index");
                    }

                    return Redirect("~/Home/Index");
                }
                
                else
                {
                    _apiService.PutAccount(accountHandler).Wait();
                    
                    return Redirect("~/Home/Index");
                }
            }
        }

        public async Task<IActionResult> Index(int? Id)
        {
            ViewBag.LimmitValue = Convert.ToDecimal(_configuration.GetSection("Limit").GetSection("Value").Value);

            if (Id == default)
            {
                _viewModel.UsersWithAccounts = _apiService.GetAllUsers().Result.ToList();
            }

            else
            {
                _viewModel.UserWithAccounts = _apiService.GetUser(Convert.ToInt32(Id)).Result;
            }
            
            return View(_viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
