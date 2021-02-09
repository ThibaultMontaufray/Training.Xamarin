using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XANTI.View.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            earthImg.Opacity = 0;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            int periodOfDay =  360 - (int)((360 * DateTime.Now.Hour) / 24);
            earthImg.Opacity = 0;
            earthImg.FadeTo(1, 1000);
            earthImg.RotateTo(periodOfDay, 1000, Easing.SinInOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            earthImg.Opacity = 0;
            earthImg.RotateTo(0);
        }
    }
}