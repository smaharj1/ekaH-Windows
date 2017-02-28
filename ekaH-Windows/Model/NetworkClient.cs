using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    class NetworkClient
    {
        private HttpClient httpClient;

        private static NetworkClient client;

        private NetworkClient ()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseConnection.URI);
            
            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static NetworkClient getInstance()
        {
            if (client == null)
            {
                client = new NetworkClient();
            }

            return client;
        }

        public HttpClient getHttpClient()
        {
            return httpClient;
        }
    }
}
