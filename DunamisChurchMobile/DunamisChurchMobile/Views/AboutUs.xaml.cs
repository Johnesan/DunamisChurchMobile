using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DunamisChurchMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private async void PapaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Papa());
        }

        private async void MamaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Mama());
        }
    }
}
