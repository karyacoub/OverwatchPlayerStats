using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    class PlayerFinder : APIRequester
    {
        private const string URL = "https://playoverwatch.com/en-us/search/account-by-name/";
        public PlayerFinder() : base()
        {
            client.BaseAddress = new Uri(URL);
        }

        protected override string getResponseString(string playerUsername)
        {
            HttpResponseMessage response = client.GetAsync(playerUsername).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return String.Format("{0}: {1}", response.StatusCode, response.ReasonPhrase);
        }
        public string findUser(string playerUsername)
        {
            return getResponseString(playerUsername);
        }
    }
}
