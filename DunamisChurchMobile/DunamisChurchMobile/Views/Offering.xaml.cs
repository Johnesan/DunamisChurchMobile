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
    public partial class Offering : ContentPage
    {
        public Offering()
        {
            InitializeComponent();
            webView.Source = "http://churchplus.co";
            //BindingContext = new ContentPageViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await progressBar.ProgressTo(0.9, 900, Easing.SpringIn);

        }
        private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            progressBar.IsVisible = true;
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            progressBar.IsVisible = false;

        }
    }

}

