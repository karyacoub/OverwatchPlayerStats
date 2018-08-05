using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    class PlayerFinder : APIRequester
    {
        private const string URL = "https://playoverwatch.com/en-us/search/account-by-name/";
        private Player[] allPlayers;
        private List<Player> playersToDisplay = new List<Player>();
        private int lastPlayerIndex = 0; // keeps track of the index position of player in allPlayers that was last displayed

        public PlayerFinder() : base()
        {
            client.BaseAddress = new Uri(URL);
        }

        // searches for all player names that match search query
        public List<Player> findUser(string playerUsername)
        {
            string response = getResponseString(playerUsername);

            // create an array of player objects from the JSON response string
            // if allPlayers is already initialized, reference will be set to a new array, old array will be garbage collected at some point
            allPlayers = Newtonsoft.Json.JsonConvert.DeserializeObject<Player[]>(response);

            return loadTenMorePlayers();
        }

        // enables loading 10 players at a time to improve performance
        public List<Player> loadTenMorePlayers()
        {
            if(allPlayers == null || allPlayers.Length == 0)
            {
                lastPlayerIndex = 0;
                playersToDisplay = new List<Player>();
                return playersToDisplay;
            }

            int temp = lastPlayerIndex + 10;
            for(; lastPlayerIndex < temp; lastPlayerIndex++)
            {
                if(lastPlayerIndex >= allPlayers.Length)
                {
                    break;
                }
                else
                {
                    playersToDisplay.Add(allPlayers[lastPlayerIndex]);
                }
            }

            return playersToDisplay;
        }
    }
}
