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
        private Player currentPlayerInfo;

        public StatsPage(Player player)
        {
            InitializeComponent();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            currentPlayerInfo = player;

            generateStatsObjectAsync(currentPlayerInfo.platform, currentPlayerInfo.urlName);

            
        }

        async private Task<Statistics> generateStatsObjectAsync(string platform, string username)
        {
            setLoadingStatus(loadingGrid1, loadingIndicator1, true);
            setLoadingStatus(loadingGrid2, loadingIndicator2, true);
            setLoadingStatus(loadingGrid3, loadingIndicator3, true);
            setLoadingStatus(loadingGrid4, loadingIndicator4, true);

            Task<Statistics> playerStatsTask = statsGenerator.generateStatsObjectAsync(platform, username);

            currentPlayerStats = await playerStatsTask;

            setLoadingStatus(loadingGrid1, loadingIndicator1, false);
            setLoadingStatus(loadingGrid2, loadingIndicator2, false);
            setLoadingStatus(loadingGrid3, loadingIndicator3, false);
            setLoadingStatus(loadingGrid4, loadingIndicator4, false);
            
            /* TEMPORARY */
            Frame portraitFrame = new Frame
            {
                Content = new Image
                {
                    Source = currentPlayerInfo.portrait,
                },
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 10,
                HasShadow = true
            };

            Label usernameViewCell = new Label
            {
                Text = currentPlayerInfo.urlName,
                TextColor = Color.White
            };

            generalGrid.IsVisible = true;

            generalGrid.Children.Add(portraitFrame, 0, 0);

            generalGrid.Children.Add(usernameViewCell, 1, 0);
            /* TEMPORARY */

            return currentPlayerStats;
        }

        private void setLoadingStatus(Grid grid, ActivityIndicator loadingIndicator, bool status)
        {
            grid.IsVisible = status;
            loadingIndicator.IsVisible = status;
            loadingIndicator.IsRunning = status;
        }

        private void setLoadingIndicatorStatus(ActivityIndicator indicator, bool status)
        {
            indicator.IsRunning = status;
            indicator.IsVisible = status;
        }

        private void setLoadingGridVisibility(Grid grid, bool status)
        {
            grid.IsVisible = status;
        }
    }
}