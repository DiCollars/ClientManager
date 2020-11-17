using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClientManager.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public List<Account> Accounts { get; set; }
    }
}