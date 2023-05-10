using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class MonthlyAverage
    {
        private const string MonthlyAverageUrl = "https://fxdatapi.com/v1/monthly_average/";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public MonthlyAverage(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetMonthlyAverage(int year, int month)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            var response = await Client.GetAsync($"{MonthlyAverageUrl}{year}/{month}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);
                return jsonResponse;
            }

            return null;
        }
    }
}
