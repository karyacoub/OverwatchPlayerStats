using Newtonsoft.Json;

namespace OverwatchPlayerStats
{
    class Statistics
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("endorsement")]
        public EndorsementStats endorsement { get; set; }

        [JsonProperty("private")]
        public bool isPrivate { get; set; }

        [JsonProperty("stats")]
        public GameplayStatistics gameplayStats;
    }
}
