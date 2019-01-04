using Newtonsoft.Json;

namespace OverwatchPlayerStats
{   
    public class GameplayStatistics
    {
        /* developer's note: each of the following fields has relevant stats for both quickplay and 
           competitive gamemodes. I would have made the top top level of this class heirarchy 
           Competitive and Quickplay, instead of splitting each field into competitive stats and 
           quickplay stats, but the api this application is using is structured in a way that splits each
           data member into competitive and quickplay. */
        
        [JsonProperty("top_heroes")]
        public TopHeroes topHeroStats { get; set; }

        [JsonProperty("combat")]
        public VariableStat combatStats { get; set; }

        [JsonProperty("match_awards")]
        public VariableStat matchAWards { get; set; }

        [JsonProperty("assists")]
        public VariableStat assists { get; set; }

        [JsonProperty("average")]
        public VariableStat average { get; set; }

        [JsonProperty("miscellaneous")]
        public VariableStat misc { get; set; }

        [JsonProperty("best")]
        public VariableStat best { get; set; }

        [JsonProperty("game")]
        public VariableStat game { get; set; }
    }
}
