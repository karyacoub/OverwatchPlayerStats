using Newtonsoft.Json;
using System.Collections.Generic;

namespace OverwatchPlayerStats
{
    /* developer's note: the reason these classes are laid out this way is entirely due to the
       way the API outlines the requested JSON object, as well as how the Newtonsoft JSON API 
       deserializes JSON objects. The API lays out the JSON object as the following:
        "top_heroes": {
            "quickplay": {
                "played": [
                {
                    "hero": "Roadhog",
                    "img": ...,
                    "played": ...
                },
                {
                    "hero": "Reinhardt",
                    "img": ...,
                    "played": ...
                }, 
                ... ], 
                "games_won": [
                {
                    "hero": "Roadhog",
                    "img": ...,
                    "games_won": ...
                },
                {
                    "hero": "Reinhardt",
                    "img": ...,
                    "games_won": ...
                },
                ...],
                ...}
                },
                ...
    Instead of having each hero be a seperate object, with data members such as playtime, number of games 
    won, weapon accuracy, ..., each attribute is made into a seperate object, which the attribute containing
    relevant information about each hero. Hence, in this class heirarchy, each attribute will contain
    a list of heroes and their relevant statistic */

    public class TimePlayedStat
    {
        [JsonProperty("hero")]
        public string hero { get; set; }
        [JsonProperty("img")]
        public string img { get; set; }
        [JsonProperty("played")]
        public string timePlayed { get; set; }
    }

    public class GamesWonStat
    {
        [JsonProperty("hero")]
        public string hero { get; set; }
        [JsonProperty("img")]
        public string img { get; set; }
        [JsonProperty("games_won")]
        public string gamesWon { get; set; }
    }

    public class WeaponAccuracyStat
    {
        [JsonProperty("hero")]
        public string hero { get; set; }
        [JsonProperty("img")]
        public string img { get; set; }
        [JsonProperty("weapon_accuracy")]
        public string weaponAccuracy { get; set; }
    }

    public class ElimsPerLifeStat
    {
        [JsonProperty("hero")]
        public string hero { get; set; }
        [JsonProperty("img")]
        public string img { get; set; }
        [JsonProperty("eliminations_per_life")]
        public string elimsPerLife { get; set; }
    }

    public class BestMultikillStat
    {
        [JsonProperty("hero")]
        public string hero { get; set; }
        [JsonProperty("img")]
        public string img { get; set; }
        [JsonProperty("multikill_best")]
        public string bestMultikill { get; set; }
    }

    public class GameType
    {
        [JsonProperty("played")]
        public List<TimePlayedStat> timePlayed { get; set; }

        [JsonProperty("games_won")]
        public List<GamesWonStat> gamesWon { get; set; }

        [JsonProperty("weapon_accuracy")]
        public List<WeaponAccuracyStat> weaponAccuracy { get; set; }

        [JsonProperty("eliminations_per_life")]
        public List<ElimsPerLifeStat> elimsPerLife { get; set; }

        [JsonProperty("multikill_best")]
        public List<BestMultikillStat> bestMultikill { get; set; }
    }

    public class TopHeroes
    {
        [JsonProperty("quickplay")]
        public GameType quickplay { get; set; }
        [JsonProperty("competitive")]
        public GameType competitive { get; set; }
    }
}
