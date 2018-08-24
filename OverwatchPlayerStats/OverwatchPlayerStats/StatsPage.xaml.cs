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
        public StatsPage()
        {
            InitializeComponent();

            // Remove navigation bar, as it is unnecessary for this page
            NavigationPage.SetHasNavigationBar(this, false);

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}