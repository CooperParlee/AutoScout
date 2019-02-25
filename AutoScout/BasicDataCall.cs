using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AutoScout
{
    public class BasicDataCall
    {
        public readonly string baseUrl = "https://www.thebluealliance.com/api/v3/";
        private string apiToken = "";

        public BasicDataCall(string apiToken)
        {
            UpdateApiToken(apiToken);
        }
        public async Task GetTeamData(int teamNumber)
        {
            string url = "";

            if (teamNumber >= 1 && teamNumber <= 9999)
            {
                url = baseUrl + "team/" + "frc" + teamNumber;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            Console.Out.WriteLine("uri " + url);
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("X-TBA-Auth-Key", apiToken);
                Console.Out.WriteLine("Request" + request.ToString());
                using (HttpResponseMessage response = await HttpsApiLib.HttpsApiManager.GetApiClient().SendAsync(request))
                {
                    Console.Out.WriteLine(response.Content);
                    Console.Out.WriteLine(response.ReasonPhrase);
                    Console.Out.WriteLine(response.StatusCode);
                    Console.Out.WriteLine(response.Headers);
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public void UpdateApiToken(string newToken)
        {
            apiToken = newToken;
        }
    }
}
