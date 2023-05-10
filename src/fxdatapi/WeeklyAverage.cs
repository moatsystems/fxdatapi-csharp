using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class WeeklyAverage
    {
        private const string WeeklyAverageUrl = "https://fxdatapi.com/v1/weekly_average/";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public WeeklyAverage(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetWeeklyAverage(string fromDate, string toDate)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            var response = await Client.GetAsync($"{WeeklyAverageUrl}{fromDate}/{toDate}");

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
