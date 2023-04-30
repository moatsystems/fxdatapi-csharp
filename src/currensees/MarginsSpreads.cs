using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Currensees
{
    public class MarginsSpreads
    {
        private Auth _auth;

        public MarginsSpreads(Auth auth)
        {
            _auth = auth;
        }

        public async Task<string> GetAllMarginsSpreads(string username, int day, int month, int year)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://currensees.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (_auth.Cookie != null)
                {
                    client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);
                }

                HttpResponseMessage response = await client.GetAsync($"v1/margins_spreads?username={username}&day={day}&month={month}&year={year}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return null;
        }

        public async Task<string> GetMarginSpreadById(string uuid, string username, int day, int month, int year)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://currensees.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (_auth.Cookie != null)
                {
                    client.DefaultRequestHeaders.Add("Cookie", _auth.Cookie);
                }

                HttpResponseMessage response = await client.GetAsync($"v1/margins_spreads/{uuid}?username={username}&day={day}&month={month}&year={year}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return null;
        }
    }
}
