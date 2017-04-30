using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// This class handles the connection with the ekah server making it easier to get the client of the network.
    /// </summary>
    class NetworkClient
    {
        /// <summary>
        /// It holds the HTTP client of the application that holds the connection addresses.
        /// </summary>
        private HttpClient m_httpClient { get; set; }

        /// <summary>
        /// It holds the instance of the class in order to make it a singleton class.
        /// </summary>
        private static NetworkClient m_client { get; set; }

        /// <summary>
        /// It is the constructor. It initializes the HTTP client for making server calls.
        /// </summary>
        private NetworkClient ()
        {
            m_httpClient = new HttpClient();
            m_httpClient.BaseAddress = new Uri(BaseConnection.g_URI);
            
            // Add an Accept header for JSON format.
            m_httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// It makes an instance of this singleton class making only one object of NetworkClient.
        /// </summary>
        /// <returns>Returns an instance of NetworkClient class to make connections.</returns>
        public static NetworkClient getInstance()
        {
            if (m_client == null)
            {
                m_client = new NetworkClient();
            }

            return m_client;
        }

        /// <summary>
        /// It returns the HTTP client.
        /// </summary>
        /// <returns>Returns the HTTP client.</returns>
        public HttpClient getHttpClient()
        {
            return m_httpClient;
        }
    }
}
