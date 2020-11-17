using ClientManagerMVC.JsonModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManagerMVC.HttpService.ApiService
{
    public interface IApiService
    {
        Task<IEnumerable<UserWithAccountsJson>> GetAllUsers();

        Task<UserWithAccountsJson> GetUser(int id);

        Task PostNewUser(UserJson newUser);

        Task PostNewAccount(AccountJson newAccount);

        Task PutUser(UserJson user);

        Task PutAccount(AccountHandlerJson account);

        Task DeleteUser(int id);

        Task DeleteAccount(int id);
    }
}
