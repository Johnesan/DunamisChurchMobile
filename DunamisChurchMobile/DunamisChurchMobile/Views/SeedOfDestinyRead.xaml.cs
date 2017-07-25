using DunamisChurchMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DunamisChurchMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeedOfDestinyRead : ContentPage
    {
        public SeedOfDestinyRead()
        {
            InitializeComponent();
            BindingContext = new SeedOfDestinyReadViewModel();
            var seedOfDestinies = BindingContext as ObservableCollection<SeedOfDestinyRead>;            
        }

        private async void OnSingleSeedOfDestinySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var singleSeedOfDestiny = e.SelectedItem as Models.SeedOfDestiny;
            if(singleSeedOfDestiny.created > DateTime.Now)
            {
                await DisplayAlert("Locked!", "You cannot view this Seed Of Destiny until " + singleSeedOfDestiny.created.ToString("dd/MM/yyyy"), "OK");
                return;
            }
            var msg = singleSeedOfDestiny.msg;


            await Navigation.PushAsync(new SeedOfDestinyReadSingle(msg)
            {
                BindingContext = singleSeedOfDestiny
            });
        }
    }
}
