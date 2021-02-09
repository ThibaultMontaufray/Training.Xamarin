using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XANTI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicePage : ContentPage
    {
        public ServicePage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object, string>(this, "UpdateLabelService", (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ServiceLabel.Text = e;
                });
            });

            MessagingCenter.Subscribe<object, string>(this, "UpdateLabelBackground", (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    BackgroundLabel.Text = e;
                });
            });

            btnServiceStart.IsEnabled = true;
            btnServiceStop.IsEnabled = false;
        }
        private void btnServiceStart_Clicked(object sender, EventArgs e)
        {
            App.CrossPlatform.StartTask(37);
            btnServiceStart.IsEnabled = false;
            btnServiceStop.IsEnabled = true;
        }
        private void btnServiceStop_Clicked(object sender, EventArgs e)
        {
            App.CrossPlatform.StopTask();
            btnServiceStart.IsEnabled = true;
            btnServiceStop.IsEnabled = false;
        }
    }
}