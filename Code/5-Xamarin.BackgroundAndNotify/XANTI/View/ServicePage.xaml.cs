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

            btnServiceStart.IsEnabled = true;
            btnServiceStop.IsEnabled = false;
        }
        private void btnServiceStart_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<object, string>(this, "ServiceAction", "start");

            btnServiceStart.IsEnabled = false;
            btnServiceStop.IsEnabled = true;
        }
        private void btnServiceStop_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<object, string>(this, "ServiceAction", "stop");

            btnServiceStart.IsEnabled = true;
            btnServiceStop.IsEnabled = false;
        }
    }
}