using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchPlayerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            StatisticsGenerator statsGenerator = new StatisticsGenerator();
            Task<Statistics> statsTask = statsGenerator.generateStatsObjectAsync("pc", "krem-21739");
        }

        async public static Task<Statistics> genStats()
        {
            StatisticsGenerator statsGenerator = new StatisticsGenerator();

            Task<Statistics> statsTask = statsGenerator.generateStatsObjectAsync("pc", "krem-21739");

            Statistics stats = await statsTask;

            return stats;
        }
    }
}
