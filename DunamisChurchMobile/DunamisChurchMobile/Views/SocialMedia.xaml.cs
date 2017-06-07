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
    public partial class SocialMedia : ContentPage
    {
        public SocialMedia()
        {
            InitializeComponent();
            BindingContext = new SocialMediaViewModel(this.Navigation);
        }
    }
}
