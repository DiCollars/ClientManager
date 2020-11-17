using ClientManager.Models;
using ClientManagerAPI.Models;
using System.Collections.Generic;

namespace ClientManager.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<UserWithAccounts> GetAll();

        UserWithAccounts GetById(int id);

        void Add(User user);

        void Update(User user);

        void Remove(int id);
    }
}