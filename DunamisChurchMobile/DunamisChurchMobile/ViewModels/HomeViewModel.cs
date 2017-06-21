using DunamisChurchMobile.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace DunamisChurchMobile
{
    public class HomeViewModel : BaseViewModel
    {
        private INavigation Navigation;
        public HomeViewModel(INavigation _Navigation)
        {

            TestimoniesCommand = new Command(TestimoniesPage);
            MessageLibraryCommand = new Command(MessageLibraryPage);
            EventCommand = new Command(EventPage);
            OnlineGivingCommand = new Command(OnlineGivingPage);
            HomeChurchCommand = new Command(HomeChurchPage);
            DunamisTvCommand = new Command(DunamisTvPage);
            SeedOfDestinyCommand = new Command(SeedOfDestinyPage);

            Navigation = _Navigation;

        }

        public ICommand TestimoniesCommand { private set; get; }
        public ICommand MessageLibraryCommand { private set; get; }
        public ICommand EventCommand { private set; get; }
        public ICommand OnlineGivingCommand { private set; get; }
        public ICommand HomeChurchCommand { private set; get; }
        public ICommand DunamisTvCommand { private set; get; }
        public ICommand SeedOfDestinyCommand { get; set; }



        public void OnlineGivingPage()
        {
            Navigation.PushAsync(new Offering());

        }

        public void TestimoniesPage()
        {
            Navigation.PushAsync(new Testimonies());

        }

        public void DunamisTvPage()
        {
            Navigation.PushAsync(new DunamisTV());

        }

        public void HomeChurchPage()
        {
            Navigation.PushAsync(new HomeChurch());

        }



        public void EventPage()
        {
            Navigation.PushAsync(new Events());

        }

        public void MessageLibraryPage()
        {
            Navigation.PushAsync(new MessageLibrary());

        }
        public void SeedOfDestinyPage()
        {
            Navigation.PushAsync(new SeedOfDestiny());
        }
    }
}
