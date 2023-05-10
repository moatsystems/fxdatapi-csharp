using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class Performances
    {
        private Auth _auth;

        public Performances(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetAllPerformances(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fxdatapi.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

                string requestUri = $"v1/performances?username={username}";
                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }

            return null;
        }

        public async Task<string> GetPerformanceById(string performanceId, string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://fxdatapi.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

                string requestUri = $"v1/performances/{performanceId}?username={username}";
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
