using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class Currencies
    {
        private const string CurrenciesUrl = "https://fxdatapi.com/v1/currencies";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public Currencies(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetAllCurrencies(string username, int day, int month, int year)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            string requestUrl = $"{CurrenciesUrl}?username={username}&day={day}&month={month}&year={year}";
            var response = await Client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }

            return null;
        }

        public async Task<string> GetCurrencyById(string currencyId, string username, int day, int month, int year)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            string requestUrl = $"{CurrenciesUrl}/{currencyId}?username={username}&day={day}&month={month}&year={year}";
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
