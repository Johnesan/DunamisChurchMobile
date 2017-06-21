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
    public partial class Testimonies : ContentPage
    {
        public Testimonies()
        {
            InitializeComponent();
            BindingContext = new TestimoniesViewModel();
        }
              
        private async void AddNewTestimonyClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new TestimoniesAddNew());
        }
    }
}
