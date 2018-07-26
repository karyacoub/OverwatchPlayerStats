using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    abstract class APIRequester
    {
        protected HttpClient client;
        protected string playerUsername;

        protected APIRequester()
        {
            client = new HttpClient();

            // ensure that the string that is returned is in JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            playerUsername = null;
        }

        // dispose of client when object is garbage-collected
        ~APIRequester()
        {
            client.Dispose();
        }

        public void setPlayerUsername(string username)
        {
            playerUsername = username;
        }

        protected abstract string getResponseString();
    }
}
