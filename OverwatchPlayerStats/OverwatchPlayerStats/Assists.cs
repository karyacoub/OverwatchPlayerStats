using Newtonsoft.Json;
using System.Collections.Generic;

namespace OverwatchPlayerStats
{
    class AssistStat
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("value")]
        public string value { get; set; }
    }

    class Assists
    {
        [JsonProperty("quickplay")]
        public List<CombatStat> quickplay { get; set; }
        [JsonProperty("competitive")]
        public List<CombatStat> competitive { get; set; }
    }
}
