using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XANTI.ViewModel;

namespace XANTI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountPage : ContentPage
    {
        TimeViewModel _viewModel;

        public CountPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TimeViewModel();
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.Data.Current = DateTime.Now;
        }
    }
}