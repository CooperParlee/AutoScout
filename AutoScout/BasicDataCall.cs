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
        public readonly string baseUrl = "www.thebluealliance.com/api/v3/";
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
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("X-TBA-Auth-Key", apiToken);
                using (HttpResponseMessage response = await HttpsApiLib.HttpsApiManager.GetApiClient().SendAsync(request))
                {

                }
            }
        }

        public void UpdateApiToken(string newToken)
        {
            apiToken = newToken;
            //HttpsApiLib.HttpsApiManager.se
        }
    }
}
