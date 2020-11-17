using System;
using System.Net.Http;

namespace ClientManagerMVC.HttpService
{
    public class ApiCatcher
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5000/api/");
            return Client;
        }
    }
}
