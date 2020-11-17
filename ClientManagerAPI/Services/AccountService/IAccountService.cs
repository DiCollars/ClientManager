using ClientManager.Models;
using ClientManagerAPI.Models;

namespace ClientManager.Services.AccountService
{
    public interface IAccountService
    {
        void CreateAccount(Account newAccount);

        void UpdateAccount(int accountId, Operation operation, decimal sum);

        void Remove(int accountId);
    }
}
