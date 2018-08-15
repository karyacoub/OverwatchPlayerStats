using Newtonsoft.Json;

namespace OverwatchPlayerStats
{
    struct Visibility
    {
        public string name { get; set; }
        public bool isPublic { get; set; }
        public bool isPrivate { get; set; }
        public bool isFriendsOnly { get; set; }

        public Visibility(Visibility visibility)
        {
            name = visibility.name;
            isPublic = visibility.isPublic;
            isPrivate = visibility.isPrivate;
            isFriendsOnly = visibility.isFriendsOnly;
        }
    }

    class Player
    {
        public string platform { get; set; }
        public string urlName { get; set; }
        public int level { get; set; }
        public string portrait { get; set; }
        public Visibility visibility;

        [JsonConstructor]
        public Player(string platform, string urlName, int level, string portrait, Visibility visibility)
        {
            this.platform = platform;
            this.urlName = urlName;
            this.level = level;
            this.portrait = portrait;
            this.visibility = new Visibility(visibility);
        }
    }
}
