using ClientManager.Models;
using System.Collections.Generic;

namespace ClientManagerAPI.Models
{
    public class UserWithAccounts
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
