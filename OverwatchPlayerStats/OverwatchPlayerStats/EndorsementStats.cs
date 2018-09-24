using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
        [JsonProperty("sportsmanship")]
        public DeserializedEndorsement sportsmanship { get; set; }
        [JsonProperty("shotcaller")]
        public DeserializedEndorsement shotcaller { get; set; }
        [JsonProperty("teammate")]
        public DeserializedEndorsement teammate { get; set; }
    }
}
