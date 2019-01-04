using Newtonsoft.Json;
using System.Collections.Generic;

namespace OverwatchPlayerStats
{
    /* developer's note: as most of the objects in the returned JSON object are laid out in the same exact way (lists of key-value
     * pairs, with the key being the title of the statistic and the value being the actual statistic), I decided it would make the most sense to
     * have one object (VariableStat) represent all of them to save on making additional unnecessary classes 
     */

    public class VariableStatElement
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("value")]
        public string value { get; set; }
    }

    public class VariableStat
    {
        [JsonProperty("quickplay")]
        public List<VariableStatElement> quickplay { get; set; }
        [JsonProperty("competitive")]
        public List<VariableStatElement> competitive { get; set; }
    }
}