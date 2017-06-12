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
    public partial class Mama : ContentPage
    {
        public Mama()
        {
            InitializeComponent();

            var ImagesUrl = new List<string>
            {
                "mama1.jpg",
                "mama2.jpg",
                "mama3.jpg"
            };

            ImageCarousel.ItemsSource = ImagesUrl;
            BindingContext = new MamaViewModel(this.Navigation);
        }
    }
}
