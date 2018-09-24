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

        /*public DeserializedEndorsement(DeserializedEndorsement endorsement)
        {
            /*value = endorsement.value;
            rate = endorsement.rate;
        }*/
    }

    class EndorsementStats
    {
        [JsonProperty("sportsmanship")]
        public DeserializedEndorsement sportsmanship { get; set; }
        [JsonProperty("shotcaller")]
        public DeserializedEndorsement shotcaller { get; set; }
        [JsonProperty("teammate")]
        public DeserializedEndorsement teammate { get; set; }

        public EndorsementStats(/*EndorsementStats endorsement*/)
        {
            /*sportsmanship = new DeserializedEndorsement(endorsement.sportsmanship);
            shotcaller = new DeserializedEndorsement(endorsement.shotcaller);
            teammate = new DeserializedEndorsement(endorsement.teammate);*/
        }
    }
}
