﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OverwatchPlayerStats
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private void searchButtonPressed(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(searchBar.Text))
            {
                Content.Navigation.PushAsync(new SearchPage(searchBar.Text));
            }
            
        }
    }
}