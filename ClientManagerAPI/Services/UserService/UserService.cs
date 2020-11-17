using ClientManager.Models;
using ClientManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientManager.Services.UserService
{
    public class UserService : IUserService
    {
        private Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            if (user.Name != default && user.Name != "" && user.LastName != default
                && user.LastName != "" && !_context.Users.Any(u => u.Name == user.Name && u.LastName == user.LastName))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            else
            {
                throw new Exception("User already exist or invalid user name or lastname.");
            }
        }

        public IEnumerable<UserWithAccounts> GetAll()
        {
            return _context.Users.Include(u => u.Accounts).Select(u => new UserWithAccounts()
            {
                Id = u.Id,
                FullName = u.Name + " " + u.LastName,
                Email = u.Email,
                Accounts = u.Accounts
            });
        }

        public UserWithAccounts GetById(int id)
        {

            var currentUser = _context.Users.Include(u => u.Accounts).FirstOrDefault(u => u.Id == id);

            if (currentUser != null)
            {
                var userWithAccounts = new UserWithAccounts()
                {
                    Id = currentUser.Id,
                    FullName = currentUser.Name + " " + currentUser.LastName,
                    Email = currentUser.Email,
                    Accounts = currentUser.Accounts
                };

                return userWithAccounts;
            }
            else
            {
                return null;
            }
        }

        public void Remove(int id)
        {
            if (_context.Users.Any(u => u.Id == id))
            {
                var user = _context.Users.First(u => u.Id == id);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There is not such a user in the database.");
            }
        }

        public void Update(User user)
        {
            if (_context.Users.Any(u => u.Id == user.Id))
            {
                var currentUser = _context.Users.First(u => u.Id == user.Id);

                if (user.LastName != currentUser.LastName && user.LastName != "" && user.LastName != default)
                {
                    currentUser.LastName = user.LastName;
                }

                if (user.Name != currentUser.Name && user.Name != "" && user.Name != default)
                {
                    currentUser.Name = user.Name;
                }

                if (user.Email != currentUser.Email && user.Email != "" && user.Email != default)
                {
                    currentUser.Email = user.Email;
                }

                _context.Users.Update(currentUser);
                _context.SaveChanges();
            }

            else
            {
                throw new Exception("There is not such a user in the database. Or you data was invalid.");
            }
        }
    }
}
