using ClientManager.Models;
using ClientManager.Services;
using ClientManager.Services.AccountService;
using ClientManagerAPI.Models;
using System;
using System.Linq;

namespace ClientManagerAPI.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private Context _context;

        public AccountService(Context context)
        {
            _context = context;
        }

        public void CreateAccount(Account newAccount)
        {
            if (_context.Users.Any(u => u.Id == newAccount.UserId) && newAccount.Score == 0)
            {
                _context.Accounts.Add(newAccount);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User is not exist or account's scope not 0");
            }
        }

        public void Remove(int accountId)
        {
            if (_context.Accounts.Any(a => a.Id == accountId))
            {
                var currentAccount = _context.Accounts.First(a => a.Id == accountId);
                _context.Accounts.Remove(currentAccount);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Account is not exist.");
            }
        }

        public void UpdateAccount(int accountId, Operation operation, decimal sum)
        {
            if (!_context.Accounts.Any(a => a.Id == accountId))
            {
                throw new Exception("Account is not exist.");
            }
            else
            {
                var currentAccount = _context.Accounts.First(a => a.Id == accountId);

                switch (operation)
                {
                    case Operation.Increase:
                        currentAccount.Score += sum;
                        break;

                    case Operation.Decrease:
                        if (currentAccount.Score - sum < 0)
                        {
                            throw new Exception("Insufficient funds to write off.");
                        }
                        else
                        {
                            currentAccount.Score -= sum;
                        }
                        break;

                    default:
                        throw new Exception("Invalid operation");
                }

                _context.Accounts.Update(currentAccount);
                _context.SaveChanges();
            }
        }
    }
}
