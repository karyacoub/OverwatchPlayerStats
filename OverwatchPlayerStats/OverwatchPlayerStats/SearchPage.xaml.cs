using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OverwatchPlayerStats
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        PlayerFinder playerSearch = new PlayerFinder();
        ObservableCollection<Player> playerSource;

		public SearchPage (string searchTerm)
		{
            InitializeComponent ();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            playerSource = playerSearch.getPlayerList();

            playerList.ItemsSource = playerSource;

            // insert user's search term from the search bar in MainPage into the search bar for this page
            searchBar.Text = searchTerm;

            generatePlayerListAsync();
        }

        private void searchButtonPressed(object sender, EventArgs e)
        {
            generatePlayerListAsync();
        }

        private void onSearchbarTextChanged(object sender, TextChangedEventArgs e)
        {
            if(searchBar.Text == "")
            {
                playerSource.Clear();
            }
        }

        private void lastElementReached(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == (playerSource[playerSource.Count - 1]))
            {
                playerSearch.loadTenMorePlayers();
            }
        }

        private void itemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Player selectedPlayer = (Player)(e.SelectedItem);
            Content.Navigation.PushAsync(new StatsPage(selectedPlayer.platform, selectedPlayer.urlName));
        }

        // generate player list asyncronously so the UI thread is not blocked
        // this is important so that the ActivityIndicator can be displayed in order for the user to know that there is something happening in the background
        async private Task<int> generatePlayerListAsync()
        {
            // display loading indicator
            setLoadingStatus(loadingGrid, loadingIndicator, true);

            // start asyncronous player list generation
            Task<int> playerListStatus = playerSearch.generatePlayerListAsync(searchBar.Text);

            // the "await" keyword signals that generatePlayerListAsync cannot continue running until playerListStatus finishes up
            // meanwhile, control is given to the current method's caller so that execution of UI code can continue
            int status = await playerListStatus;

            setLoadingStatus(loadingGrid, loadingIndicator, false);

            return status;
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