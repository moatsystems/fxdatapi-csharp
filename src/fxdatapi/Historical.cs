using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class Historical
    {
        private const string HistoricalUrl = "https://fxdatapi.com/v1/historical";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public Historical(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetAllHistoricalData(string username, string date, int day, int month, int year)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            string requestUrl = $"{HistoricalUrl}?username={username}&date={date}&day={day}&month={month}&year={year}";
            var response = await Client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }

            return null;
        }

        public async Task<string> GetHistoricalDataById(string dataId, string username, string dateString, int day, int month, int year)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            string requestUrl = $"{HistoricalUrl}/{dataId}?username={username}&date_string={dateString}&day={day}&month={month}&year={year}";
            var response = await Client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }

            return null;
        }
    }
}
