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
    public partial class Events : ContentPage
    {
        public Events()
        {
            InitializeComponent();
            BindingContext = new EventsViewModel();
        }

        private async void OnSingleEventSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var SingleEvent = e.SelectedItem as Event;


            await Navigation.PushAsync(new EventSingle()
            {
                BindingContext = SingleEvent
            });
        }
    }
}
