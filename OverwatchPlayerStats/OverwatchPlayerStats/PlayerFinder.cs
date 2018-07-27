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

        public string findUser(string playerUsername)
        {
            string response = getResponseString(playerUsername);
            Player[] item = Newtonsoft.Json.JsonConvert.DeserializeObject<Player[]>(response);
            return response;
        }
    }
}
