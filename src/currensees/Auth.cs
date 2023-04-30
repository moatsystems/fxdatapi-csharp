using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currensees
{
    public class Auth
    {
        private const string LoginUrl = "https://currensees.com/v1/login";
        private static readonly HttpClient Client = new HttpClient();
        public string Cookie { get; private set; }

        public async Task<bool> Authenticate(string username, string password)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestData = new { username = username, password = password };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(LoginUrl, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);

                if (data.message == "Login successful")
                {
                    Cookie = $"user_type=member; username={username}";
                    return true;
                }
            }

            return false;
        }
    }
}
