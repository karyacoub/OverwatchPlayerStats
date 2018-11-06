using Newtonsoft.Json;

namespace OverwatchPlayerStats
{
    struct DeserializedEndorsement
    {
        [JsonProperty("value")]
        public double value { get; set; }

        [JsonProperty("rate")]
        public int rate { get; set; }
    }

    class EndorsementStats
    {
        [JsonProperty("level")]
        public int endorsementLevel { get; set; }

        [JsonProperty("sportsmanship")]
        public DeserializedEndorsement sportsmanship { get; set; }

        [JsonProperty("shotcaller")]
        public DeserializedEndorsement shotcaller { get; set; }

        [JsonProperty("teammate")]
        public DeserializedEndorsement teammate { get; set; }
    }
}
