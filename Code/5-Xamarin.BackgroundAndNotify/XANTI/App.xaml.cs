using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XANTI.Services;

namespace XANTI
{
    public partial class App : Application
    {
        public static ICrossPlatform CrossPlatform;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
