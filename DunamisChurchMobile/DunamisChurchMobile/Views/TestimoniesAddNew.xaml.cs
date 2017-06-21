using DunamisChurchMobile.Models;
using DunamisChurchMobile.Services;
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
    public partial class TestimoniesAddNew : ContentPage
    {
        public TestimoniesAddNew()
        {
            InitializeComponent();
            BindingContext = new Testimony();
        }

        private async void OnSendTestimonyClicked(object sender, EventArgs e)
        {
            var testimony = (Testimony)BindingContext;
            ChurchPlusApis service = new ChurchPlusApis();
           var status = await service.PostTestimony(testimony);

            if (status == true)
            {
                await DisplayAlert("Successful", "Your Testimony has been Uploaded Successfully. It will be reviewed and approved in due time. Thank you for sharing!", "OK");
            }
            else
            {
               await DisplayAlert("An Error Occured", "There was a problem sending your testimony. Please try again later", "OK");
            }
            await Navigation.PopAsync();
        }

        private async void OnCancelTestimonyClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
