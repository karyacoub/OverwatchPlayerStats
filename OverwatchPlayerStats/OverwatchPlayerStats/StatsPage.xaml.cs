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

            // remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            currentPlayerInfo = player;

            generateUIElements(currentPlayerInfo.platform, currentPlayerInfo.urlName);
        }

        async private Task<Statistics> generateUIElements(string platform, string username)
        {
            // enable loading indicators
            setLoadingStatus(true);

            // generate current player statistics
            Task<Statistics> currentStatsTask = statsGenerator.generateStatsObjectAsync(platform, username);
            currentPlayerStats = await currentStatsTask;

            // disable loading indicators
            setLoadingStatus(false);

            // generate "General" page UI elements
            generateGeneralUIElements();

            // generate "Combat" page UI elements


            // generate "Heroes" page UI elements


            // generate "Misc." page UI elements


            return currentPlayerStats;
        }

        private void generateGeneralUIElements()
        {
            Frame portraitFrame = new Frame
            {
                Content = new Image
                {
                    Source = currentPlayerInfo.portrait,
                    Aspect = Aspect.AspectFill
                },
                Padding = 2,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HasShadow = true
            };

            Label usernameLabel = new Label
            {
                Text = currentPlayerInfo.name,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                FontFamily = (OnPlatform<string>)(Xamarin.Forms.Application.Current.Resources["bignoodletoo"]),
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center
            };

            generalGrid.IsVisible = true;

            generalGrid.Children.Add(portraitFrame, 0, 0);

            generalGrid.Children.Add(usernameLabel, 1, 0);
        }

        private void setLoadingStatus(bool status)
        {
            _setLoadingStatus(loadingGrid1, loadingIndicator1, status);
            _setLoadingStatus(loadingGrid2, loadingIndicator2, status);
            _setLoadingStatus(loadingGrid3, loadingIndicator3, status);
            _setLoadingStatus(loadingGrid4, loadingIndicator4, status);
        }

        private void _setLoadingStatus(Grid grid, ActivityIndicator loadingIndicator, bool status)
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