using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HttpsApiLib
{
    public class HttpsApiManager
    {
        private static HttpClient ApiClient = null;
        private static string baseURI = "";
        private static string apiToken;

        /// <summary>
        /// Initializes the HTTP Client; functions like an object instantiation would,
        /// however in this case, the class itself is static.
        /// </summary>
        /// <param name="initBaseURI"> The first value for the base URI. Default: blank. </param>
        public static void InitApiClient(string initApiToken, string initBaseURI = "https://www.thebluealliance.com/api/v3/")
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            apiToken = initApiToken;
            baseURI = initBaseURI;
        }

        /// <summary>
        /// Gets the ApiClient object for direct minipulation; potentially destructive
        /// </summary>
        /// <returns>HTTPClient object of ApiClient</returns>
        private static HttpClient GetApiClient()
        {
            return ApiClient;
        }

        /// <summary>
        /// Files a request with the base url and with the provided uri for information.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task MakeRequest(string uri)
        {
            uri = baseURI + uri;
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                //request.Headers.Authorization = new AuthenticationHeaderValue("X-TBA-Auth-Key", apiToken);
                request.Headers.Add("X-TBA-Auth-Key", apiToken);
                request.Headers.Add("User-agent", "Coop_Coop");
                Console.Out.WriteLine("Request" + request.ToString());
                using (HttpResponseMessage response = await HttpsApiLib.HttpsApiManager.GetApiClient().SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Updates the base URL that all URI are appended to.
        /// </summary>
        /// <param name="newBase">The new URL for the base.</param>
        public static void SetBaseUrl(string newBase)
        {
            baseURI = newBase;
        }
    }
}
