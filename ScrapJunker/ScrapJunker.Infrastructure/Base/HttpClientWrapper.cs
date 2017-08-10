using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Base
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public void Post<T>(string url, T body)
        {
            var httpClient = new HttpClient();

            // List data response.
            HttpResponseMessage response = httpClient.PostAsJsonAsync(url,body).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                //var dataObjects = response.Content.ReadAsAsync<object>().Result;
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.Name);
                //}
            }
            else
            {
                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
