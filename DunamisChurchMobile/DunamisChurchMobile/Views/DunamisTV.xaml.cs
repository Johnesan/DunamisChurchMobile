using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DunamisChurchMobile.Views
{
    public partial class DunamisTV : ContentPage
    {

        public DunamisTV()
        {
            InitializeComponent();
            webView.Source = "https://www.youtube.com/embed/ruMaod3QCdQ";
            //BindingContext = new ContentPageViewModel();

            //var htmlSource = new HtmlWebViewSource();

            ////the htmlSource.Html would look something like<html><body><iframe width="100%" src="https://www.youtube.com/embed/ow241ADZxE" frameborder="0" allowfullscreen></iframe></body></html>
            //htmlSource.Html = @"<html><body><iframe width=""100%"" height=""100%"" src = ""https://www.youtube.com/embed/X_cd7S8woqM?feature=player_detailpage/" + " frameborder = \"0\" allowfullscreen></iframe ></body></html>";
            //webView.Source = htmlSource;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await progressBar.ProgressTo(1.0, 1000, Easing.SpringIn);

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
