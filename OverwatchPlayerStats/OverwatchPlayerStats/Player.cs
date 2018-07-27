using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace OverwatchPlayerStats
{
    struct Visibility
    {
        private string name { get; set; }
        private bool isPublic { get; set; }
        private bool isPrivate { get; set; }
        private bool isFriendsOnly { get; set; }

        public Visibility(Visibility visibility)
        {
            this.name = visibility.name;
            this.isPublic = visibility.isPublic;
            this.isPrivate = visibility.isPrivate;
            this.isFriendsOnly = visibility.isFriendsOnly;
        }
    }

    class Player
    {
        private string platform { get; set; }
        private string urlName { get; set; }
        private int level { get; set; }
        private string portrait { get; set; }
        //[JsonProperty]
        private Visibility visibility;

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
