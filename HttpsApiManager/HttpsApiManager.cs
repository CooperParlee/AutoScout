using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HttpsApiLib
{
    public class HttpsApiManager
    {
        private static HttpClient ApiClient;

        public static void InitApiClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient GetApiClient()
        {
            return ApiClient;
        }
    }
}
