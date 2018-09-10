using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace OverwatchPlayerStats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : Xamarin.Forms.TabbedPage
    {
        private StatisticsGenerator statsGenerator = new StatisticsGenerator();
        private Statistics currentPlayerStats;

        public StatsPage(string platform, string username)
        {
            InitializeComponent();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            generateStatsObjectAsync(platform, username);
        }

        async private Task<Statistics> generateStatsObjectAsync(string platform, string username)
        {
            setLoadingIndicatorStatus(loadingIndicator1, true);
            setLoadingIndicatorStatus(loadingIndicator2, true);
            setLoadingIndicatorStatus(loadingIndicator3, true);
            setLoadingIndicatorStatus(loadingIndicator4, true);

            Task<Statistics> playerStatsTask = statsGenerator.generateStatsObjectAsync(platform, username);

            currentPlayerStats = await playerStatsTask;

            setLoadingIndicatorStatus(loadingIndicator1, false);
            setLoadingIndicatorStatus(loadingIndicator2, false);
            setLoadingIndicatorStatus(loadingIndicator3, false);
            setLoadingIndicatorStatus(loadingIndicator4, false);

            return currentPlayerStats;
        }

        private void setLoadingIndicatorStatus(ActivityIndicator indicator, bool status)
        {
            indicator.IsRunning = status;
            indicator.IsVisible = status;
        }
    }
}