using ClientManagerMVC.JsonModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerMVC.HttpService.ApiService
{
    public class ApiService : IApiService
    {
        public ApiCatcher _api = new ApiCatcher();

        private HttpClient client;

        private HttpResponseMessage response;

        public ApiService()
        {
            client = _api.Initial();
        }

        public async Task DeleteAccount(int id)
        {
            response = await client.DeleteAsync($"account/delete-account-by-id/{id}");
        }

        public async Task DeleteUser(int id)
        {
            response = await client.DeleteAsync($"user/delete-user-by-id/{id}");
        }

        public async Task<IEnumerable<UserWithAccountsJson>> GetAllUsers()
        {
            response = await client.GetAsync("user/get-all-users");
            var users = JsonConvert.DeserializeObject<IEnumerable<UserWithAccountsJson>>(response.Content.ReadAsStringAsync().Result);

            return users;
        }

        public async Task<UserWithAccountsJson> GetUser(int id)
        {
            response = await client.GetAsync($"user/get-user-by-id/{id}");
            var user = JsonConvert.DeserializeObject<UserWithAccountsJson>(response.Content.ReadAsStringAsync().Result);

            return user;
        }

        public async Task PostNewAccount(AccountJson newAccount)
        {
            HttpContent newAccountContent = new StringContent(JsonConvert.SerializeObject(newAccount), Encoding.UTF8, "application/json");
            response = await client.PostAsync("account/add-new-account", newAccountContent);
        }

        public async Task PostNewUser(UserJson newUser)
        {
            HttpContent newUserContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");
            response = await client.PostAsync("user/add-new-user", newUserContent);
        }

        public async Task PutAccount(AccountHandlerJson account)
        {
            HttpContent newAccountContent = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
            response = await client.PutAsync("account/plus-or-minus-account", newAccountContent);
        }

        public async Task PutUser(UserJson user)
        {
            HttpContent fixedUserContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            response = await client.PutAsync("user/update-user", fixedUserContent);
        }
    }
}
