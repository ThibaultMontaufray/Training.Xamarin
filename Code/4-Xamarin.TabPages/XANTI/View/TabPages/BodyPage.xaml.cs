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
    public partial class BodyPage : ContentPage
    {
        public BodyPage()
        {
            InitializeComponent();
            bodyImg.Opacity = 0;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            bodyImg.TranslationX = -250;
            bodyImg.Opacity = 0;
            bodyImg.FadeTo(1, 1000);
            bodyImg.TranslateTo(0, 0, 1000, Easing.CubicInOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            bodyImg.Opacity = 0;
            bodyImg.TranslationX = -250;
            bodyImg.TranslationY = 0;
        }
    }
}