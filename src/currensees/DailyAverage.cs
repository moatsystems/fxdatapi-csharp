using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currensees
{
    public class DailyAverage
    {
        private const string DailyAverageUrl = "https://currensees.com/v1/daily_average/";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public DailyAverage(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetDailyAverage(string date)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            var response = await Client.GetAsync(DailyAverageUrl + date);

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
