using ClientManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientManager.Services
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}