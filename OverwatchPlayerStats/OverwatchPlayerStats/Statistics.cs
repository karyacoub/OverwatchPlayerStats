using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public Statistics(/*EndorsementStats endorsement*/)
        {
            //this.endorsement = new EndorsementStats(endorsement);
        }
    }
}
