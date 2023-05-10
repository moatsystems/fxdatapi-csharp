using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class Signals
    {
        private Auth _auth;

        public Signals(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetAllSignals(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fxdatapi.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

                string requestUri = $"v1/signals?username={username}";
                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }

            return null;
        }

        public async Task<string> GetSignalById(string signalId, string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fxdatapi.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

                string requestUri = $"v1/signals/{signalId}?username={username}";
                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }

            return null;
        }
    }
}
