using DunamisChurchMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DunamisChurchMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public RootPageMaster()
        {
            InitializeComponent();
            BindingContext = new RootPageMasterViewModel();
            ListViewMenuItems.SeparatorVisibility = Xamarin.Forms.SeparatorVisibility.Default;
            ListViewMenuItems.SeparatorColor = Color.FromHex("C8C7CC");
        }



        class RootPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RootPageMenuItem> MenuItems { get; }
            public RootPageMasterViewModel()
            {
               
                MenuItems = new ObservableCollection<RootPageMenuItem>(new[]
                {
                    new RootPageMenuItem { Title = "Home", Icon = "homeIcon", TargetType = typeof(Home) },
                    new RootPageMenuItem { Title = "Dunamis TV", Icon = "dunamisTVIcon", TargetType = typeof(DunamisTV) },
                    new RootPageMenuItem { Title = "Seed Of Destiny", Icon = "seedofdestinyIcon", TargetType = typeof(SeedOfDestiny) },
                    new RootPageMenuItem { Title = "Messages", Icon = "messagesIcon", TargetType = typeof(MessageLibrary) },
                    new RootPageMenuItem { Title = "Give Online", Icon = "offeringIcon", TargetType = typeof(Offering) },
                    new RootPageMenuItem { Title = "Events", Icon = "eventsIcon", TargetType = typeof(Events) },
                    new RootPageMenuItem { Title = "Social Media", Icon = "twitterIcon", TargetType = typeof(SocialMedia) },
                    new RootPageMenuItem { Title = "About Us", Icon = "aboutIcon", TargetType = typeof(AboutUs) }
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
