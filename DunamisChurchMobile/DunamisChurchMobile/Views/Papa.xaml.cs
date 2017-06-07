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
    public partial class Papa : ContentPage
    {
        public Papa()
        {
            InitializeComponent();

            var ImagesUrl = new List<string>
            {
                "papa1.jpg",
                "papa2.jpg",
                "papa3.jpg",
                "papa4.jpg"
            };

            ImageCarousel.ItemsSource = ImagesUrl;
            BindingContext = new PapaViewModel(this.Navigation);
        }
    }
}
