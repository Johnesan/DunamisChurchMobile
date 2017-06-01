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
    public partial class MessageLibraryDrPaul : ContentPage
    {
        public MessageLibraryDrPaul()
        {
            InitializeComponent();
            BindingContext = new YoutubeViewModel("UCK_Jbyeifa1W5A4Z8uB708w");
        }

        private async void OnSingleVideoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var youtubeItem = e.SelectedItem as YoutubeItem;
            var videoId = youtubeItem.VideoId;

            await Navigation.PushAsync(new MessageLibraryDrPaulVideo(videoId)
            {
                BindingContext = youtubeItem
            });

        }
    }
}
