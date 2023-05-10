using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fxdatapi
{
    public class Convert
    {
        private const string ConvertUrl = "https://fxdatapi.com/v1/convert";
        private static readonly HttpClient Client = new HttpClient();
        private readonly Auth _auth;

        public Convert(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> ConvertCurrency(string username, string date, string baseCurrency, string targetCurrency, string amount)
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);

            var requestData = new
            {
                username = username,
                date = date,
                base_currency = baseCurrency,
                target_currency = targetCurrency,
                amount = amount
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(ConvertUrl, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(jsonResponse);
                return JsonConvert.SerializeObject(new
                {
                    base_currency = data.base_currency,
                    target_currency = data.target_currency,
                    amount = data.amount,
                    converted_amount = data.converted_amount
                });
            }

            return null;
        }
    }
}
