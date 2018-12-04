using Newtonsoft.Json;

namespace OverwatchPlayerStats
{   
    class GameplayStatistics
    {
        /* developer's note: each of the following fields has relevant stats for both quickplay and 
           competitive gamemodes. I would have made the top top level of this class heirarchy 
           Competitive and Quickplay, instead of splitting each field into competitive stats and 
           quickplay stats, but the api this application is using is structured in a way that splits each
           data member into competitive and quickplay. */
        
        [JsonProperty("top_heroes")]
        public TopHeroes topHeroStats { get; set; }

        [JsonProperty("combat")]
        public Combat combatStats { get; set; }

        [JsonProperty("match_awards")]
        public MatchAwards matchAWards { get; set; }

        [JsonProperty("assists")]
        public Assists assists { get; set; }

        /*[JsonProperty("average")]

        [JsonProperty("miscellaneous")]

        [JsonProperty("best")]

        [JsonProperty("game")]*/
    }
}
