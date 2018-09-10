using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OverwatchPlayerStats
{
    class Statistics
    {
        public string name { get; set; }

        public int level { get; set; }
        public int prestige { get; set; }
        public int totalLevel { get; set; }

        public string levelIcon { get; set; }
        public string prestigeIcon { get; set; }

        public int gamesWon { get; set; }
    }
}
