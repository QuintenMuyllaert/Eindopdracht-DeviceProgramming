using RS3.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RS3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Register for connectivity changes, be sure to unsubscribe when finished
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
            {
                var access = e.NetworkAccess;
                var profiles = e.ConnectionProfiles;
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    MainPage = new NavigationPage(new NavigationPage(new MainPage()));
                }
                else
                {
                    MainPage = new NavigationPage(new NavigationPage(new NoWifi()));
                }
            }


            MainPage = new NavigationPage(new MainPage());//Very important add this.. R.I.P. HOURS
            //MainPage = new MainPage();//grrr.exe



        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
