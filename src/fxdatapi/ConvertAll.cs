using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class ConvertAll
    {
        private const string ConvertAllUrl = "https://fxdatapi.com/v1/convert_all";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public ConvertAll(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> ConvertCurrencyAll(string username, string date, string baseCurrency, string amount)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            var requestData = new
            {
                username = username,
                date = date,
                base_currency = baseCurrency,
                amount = amount
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(ConvertAllUrl, jsonContent);

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
