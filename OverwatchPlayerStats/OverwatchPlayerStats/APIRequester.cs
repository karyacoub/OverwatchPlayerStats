using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    abstract class APIRequester
    {
        protected HttpClient client;

        protected APIRequester()
        {
            client = new HttpClient();

            // ensure that the string that is returned is in JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // dispose of client when object is garbage-collected
        ~APIRequester()
        {
            client.Dispose();
        }

        protected string getResponseString(string parameters)
        {
            HttpResponseMessage response = client.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return String.Format("{0}: {1}", response.StatusCode, response.ReasonPhrase);
        }
    }
}
