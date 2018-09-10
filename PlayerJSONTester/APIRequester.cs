using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

        async protected Task<string> getResponseStringAsync(string parameters)
        {
            Task<string> responseTask = client.GetStringAsync(parameters);

            string responseString = await responseTask;

            return responseString;
        }
    }
}
