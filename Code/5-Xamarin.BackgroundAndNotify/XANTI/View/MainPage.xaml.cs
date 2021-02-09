using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XANTI.Resx;
using XANTI.View;

namespace XANTI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void alert_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert(AppResources.Hello, AppResources.World, "Ok");
        }
        private async void countpage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CountPage());
        }
        private async void tabpage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TabPage());
        }
        private async void servicepage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ServicePage());
        }
    }
}
