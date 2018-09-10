using System;
using System.Threading.Tasks;

namespace OverwatchPlayerStats
{
    class StatisticsGenerator : APIRequester
    {
        private const string URL = "http://ow-api.herokuapp.com/stats/";

        public StatisticsGenerator()
        {
            client.BaseAddress = new Uri(URL);
        }

        async public Task<Statistics> generateStatsObjectAsync(string platform, string username)
        {
            string parameters = string.Format("{0}/us/{1}/complete", platform, username);

            Task<string> response = getResponseStringAsync(parameters);
            string responseString = await response;

            Statistics playerStats = Newtonsoft.Json.JsonConvert.DeserializeObject<Statistics>(responseString);

            return playerStats;
        }
    }
}
