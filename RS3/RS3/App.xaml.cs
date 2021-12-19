using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RS3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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
