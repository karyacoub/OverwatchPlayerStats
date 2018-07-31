using System;
using System.Collections.Generic;
using System.Text;
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
        private string platform { get; set; }
        private string urlName { get; set; }
        private int level { get; set; }
        private string portrait { get; set; }
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
