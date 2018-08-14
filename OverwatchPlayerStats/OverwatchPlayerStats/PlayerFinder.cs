using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    class PlayerFinder : APIRequester
    {
        private const string URL = "https://playoverwatch.com/en-us/search/account-by-name/";
        private ObservableCollection<Player> currentPlayerList = new ObservableCollection<Player>();
        //private ObservableCollection<Player> playersToDisplay = new ObservableCollection<Player>();
        //private int lastPlayerIndex = 0; // keeps track of the index position of player in allPlayers that was last displayed

        public PlayerFinder() : base()
        {
            client.BaseAddress = new Uri(URL);
        }

        public ObservableCollection<Player> getPlayerList()
        {
            return currentPlayerList;
        }

        // searches for all player names that match search query
        public void generatePlayerList(string playerUsername)
        {
            string response = getResponseString(playerUsername);

            // create an array of player objects from the JSON response string
            // if allPlayers is already initialized, reference will be set to a new array, old array will be garbage collected at some point
            ObservableCollection<Player> newPlayerList = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Player>>(response);

            currentPlayerList.Clear();

            foreach(Player p in newPlayerList)
            {
                currentPlayerList.Add(p);
            }
        }

        // enables loading 10 players at a time to improve performance
        /*public ObservableCollection<Player> loadTenMorePlayers()
        {
            if(allPlayers == null || allPlayers.Count == 0)
            {
                lastPlayerIndex = 0;
                playersToDisplay = new ObservableCollection<Player>();
                return playersToDisplay;
            }

            int temp = lastPlayerIndex + 10;
            for(; lastPlayerIndex < temp; lastPlayerIndex++)
            {
                if(lastPlayerIndex >= allPlayers.Count)
                {
                    break;
                }
                else
                {
                    playersToDisplay.Add(allPlayers[lastPlayerIndex]);
                }
            }

            return playersToDisplay;
        }*/
    }
}
