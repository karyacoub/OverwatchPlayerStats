using Newtonsoft.Json;

namespace OverwatchPlayerStats
{
    public class Player
    {
        [JsonProperty("platform")]
        public string platform { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("urlName")]
        public string urlName { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("portrait")]
        public string portrait { get; set; }

        [JsonProperty("isPublic")]
        public bool isPublic { get; set; }
    }
}
