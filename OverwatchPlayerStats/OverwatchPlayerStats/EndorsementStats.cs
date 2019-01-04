using Newtonsoft.Json;

namespace OverwatchPlayerStats
{
    public class DeserializedEndorsement
    {
        [JsonProperty("rate")]
        public double value { get; set; }
    }

    public class EndorsementStats
    {
        [JsonProperty("sportsmanship")]
        public DeserializedEndorsement sportsmanship { get; set; }

        [JsonProperty("shotcaller")]
        public DeserializedEndorsement shotcaller { get; set; }

        [JsonProperty("teammate")]
        public DeserializedEndorsement teammate { get; set; }

        [JsonProperty("level")]
        public int endorsementLevel { get; set; }

        [JsonProperty("icon")]
        public string endorsementIcon { get; set; }
    }
}
