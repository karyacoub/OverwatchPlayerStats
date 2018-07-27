using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    class PlayerFinder : APIRequester
    {
        public PlayerFinder() : base()
        {
            client.BaseAddress = new Uri("https://playoverwatch.com/en-us/search/account-by-name/");
        }

        protected override string getResponseString()
        {
            // if playerUsername is not set before this method is called, return null
            if (!String.IsNullOrEmpty(playerUsername))
            {
                HttpResponseMessage response = client.GetAsync(playerUsername).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }
        public string findUser()
        {
            return getResponseString();
        }
    }
}
