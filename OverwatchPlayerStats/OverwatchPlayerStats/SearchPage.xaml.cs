﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            playerSearch.generatePlayerList(searchTerm);
        }

        private void searchButtonPressed(object sender, EventArgs e)
        {
            playerSearch.generatePlayerList(searchBar.Text);
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
    }
}