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
    public partial class PersonalityPage : ContentPage
    {
        public PersonalityPage()
        {
            InitializeComponent();
            personalityPicker.SelectedIndex = 0;
        }
    }
}