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
    }
}
