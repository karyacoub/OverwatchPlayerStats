using Newtonsoft.Json;
using System.Collections.Generic;

namespace OverwatchPlayerStats
{
    /* developer's note: the reason these classes are laid out this way are entirely due to the
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
    won, weapon accuracy, ..., each attribute is made a seperate object, which the attribute containing
    relevant information about each hero. Hence, in this class heirarchy, each attribute will contain
    a list of heroes and their relevant statistic */

    class TimePlayedStat
    {
        [JsonProperty("hero")]
        public string hero;
        [JsonProperty("img")]
        public string img;
        [JsonProperty("played")]
        public string timePlayed;
    }

    class GamesWonStat
    {
        [JsonProperty("hero")]
        public string hero;
        [JsonProperty("img")]
        public string img;
        [JsonProperty("games_won")]
        public string gamesWon;
    }

    class WeaponAccuracyStat
    {
        [JsonProperty("hero")]
        public string hero;
        [JsonProperty("img")]
        public string img;
        [JsonProperty("weapon_accuracy")]
        public string weaponAccuracy;
    }

    class ElimsPerLifeStat
    {
        [JsonProperty("hero")]
        public string hero;
        [JsonProperty("img")]
        public string img;
        [JsonProperty("eliminations_per_life")]
        public string elimsPerLife;
    }

    class BestMultikillStat
    {
        [JsonProperty("hero")]
        public string hero;
        [JsonProperty("img")]
        public string img;
        [JsonProperty("multikill_best")]
        public string bestMultikill;
    }

    class GameType
    {
        [JsonProperty("played")]
        public List<TimePlayedStat> timePlayed;

        [JsonProperty("games_won")]
        public List<GamesWonStat> gamesWon;

        [JsonProperty("weapon_accuracy")]
        public List<WeaponAccuracyStat> weaponAccuracy;

        [JsonProperty("eliminations_per_life")]
        public List<ElimsPerLifeStat> elimsPerLife;

        [JsonProperty("multikill_best")]
        public List<BestMultikillStat> bestMultikill;
    }

    class TopHeroes
    {
        [JsonProperty("quickplay")]
        public GameType quickplay;
        [JsonProperty("competitive")]
        public GameType competitive;
    }
}
