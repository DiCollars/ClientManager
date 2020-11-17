using System.Text.Json.Serialization;

namespace ClientManager.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Score { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
