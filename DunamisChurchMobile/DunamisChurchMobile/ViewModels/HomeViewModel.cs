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

            PrayerCommand = new Command(PrayerPage);
            MessageLibraryCommand = new Command(MessageLibraryPage);
            EventCommand = new Command(EventPage);
            OnlineGivingCommand = new Command(OnlineGivingPage);
            TestimonyCommand = new Command(TestimonyPage);
            DunamisTvCommand = new Command(DunamisTvPage);
            SeedOfDestinyCommand = new Command(SeedOfDestinyPage);

            Navigation = _Navigation;

        }

        public ICommand PrayerCommand { private set; get; }
        public ICommand MessageLibraryCommand { private set; get; }
        public ICommand EventCommand { private set; get; }
        public ICommand OnlineGivingCommand { private set; get; }
        public ICommand TestimonyCommand { private set; get; }
        public ICommand DunamisTvCommand { private set; get; }
        public ICommand SeedOfDestinyCommand { get; set; }



        public void OnlineGivingPage()
        {
            Navigation.PushAsync(new Offering());

        }

        public void PrayerPage()
        {
            Navigation.PushAsync(new Prayers());

        }

        public void DunamisTvPage()
        {
            Navigation.PushAsync(new DunamisTV());

        }

        public void TestimonyPage()
        {
            Navigation.PushAsync(new Testimonies());

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
