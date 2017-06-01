using DunamisChurchMobile.Models;
using DunamisChurchMobile.ViewModels;
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
    public partial class SeedOfDestinyWatch : ContentPage
    {
        public SeedOfDestinyWatch()
        {
            InitializeComponent();
            BindingContext = new YoutubeViewModel("UCrDg-KgwTtv88H32I4KEZcw");
        }

        private async void OnSingleVideoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var youtubeItem = e.SelectedItem as YoutubeItem;
            var videoId = youtubeItem.VideoId;

            await Navigation.PushAsync(new SeedOfDestinyWatchVideo(videoId)
            {
                BindingContext = youtubeItem
            });
        }
    }
}
