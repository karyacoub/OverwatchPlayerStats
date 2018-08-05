using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OverwatchPlayerStats
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        PlayerFinder playerSearch = new PlayerFinder();
        List<Player> playerSource;

		public SearchPage (string searchTerm)
		{
			InitializeComponent ();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            // insert user's search term from the search bar in MainPage into the search bar for this page
            searchBar.Text = searchTerm;
        }

        private void onSearchbarTextChanged(object sender, TextChangedEventArgs e)
        {
            playerSource = playerSearch.findUser(searchBar.Text);

            playerList.ItemsSource = playerSource;
            
        }

        private void lastElementReached(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item.Equals(playerSource[playerSource.Count - 1]))
            {
                playerSource = playerSearch.loadTenMorePlayers();
                playerList.ItemsSource = null; // temporary
                playerList.ItemsSource = playerSource;
            }
        }
    }
}