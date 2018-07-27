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
		public SearchPage (string searchTerm)
		{
			InitializeComponent ();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            // insert user's search term from the search bar in MainPage into the search bar for this page
            searchBar.Text = searchTerm;

            // the searchbar OnTextChanged event handler isn't called after the above line for some reason,
            // so call it here
        }

        private void onSearchbarTextChanged(object sender, TextChangedEventArgs e)
        {
            PlayerFinder playerSearch = new PlayerFinder();
            playerSearch.setPlayerUsername(searchBar.Text);
            playerSearch.findUser();
        }
    }
}