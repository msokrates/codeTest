using System;
using System.Net.Http;

namespace PairingTest.Web
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        HttpClient httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string Get(string url)
        {
            var request = httpClient.GetAsync(new Uri(url)).Result;
            return request.Content.ReadAsStringAsync().Result;
        }
    }
}