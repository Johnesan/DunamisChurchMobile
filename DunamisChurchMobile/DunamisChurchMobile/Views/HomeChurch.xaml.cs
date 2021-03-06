﻿using DunamisChurchMobile.ViewModels;
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
    public partial class HomeChurch : ContentPage
    {
        public HomeChurch()
        {
            InitializeComponent();
        }

        public async void SearchHomeChurches()
        {
            var searchString = entry.Text;
            if (string.IsNullOrEmpty(searchString))
            {
               await DisplayAlert("No Text Entered!", "Please enter a home fellowship name or area.", "OK");
                return;
            }
            await Navigation.PushAsync(new HomeChurchAll
            {
                BindingContext = new HomeChurchViewModel(searchString)
            });
        }

        public async void ViewAllHomeChurches()
        {
            var searchString = "";
            await Navigation.PushAsync(new HomeChurchAll
            {
                BindingContext = new HomeChurchViewModel(searchString)
            });
        }


    }
}
