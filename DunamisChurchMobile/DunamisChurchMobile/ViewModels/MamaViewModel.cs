using DunamisChurchMobile.Views;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DunamisChurchMobile.ViewModels
{
    class MamaViewModel : BaseViewModel
    {
        private INavigation Navigation;
        public ICommand facebookCommand { get; private set; }
        public ICommand twitterCommand { get; private set; }
        public ICommand instagramCommand { get; set; }
        public ICommand youtubeCommand { get; set; }

        public MamaViewModel(INavigation _Navigation)
        {
            facebookCommand = new Command(facebookPage);
            twitterCommand = new Command(twitterPage);
            instagramCommand = new Command(instagramPage);
            youtubeCommand = new Command(youtubePage);
            Navigation = _Navigation;
        }



        public void facebookPage()
        {
            try
            {
                Device.OpenUri(new Uri("fb://page/222940574415209"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://www.facebook.com/Drbeckyenenche/"));
            }
        }

        public void twitterPage()
        {
            try
            {
                Device.OpenUri(new Uri("twitter://user?user_id=585030257"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://twitter.com/DrBeckyEnenche"));
            }
        }

        public void instagramPage()
        {
            try
            {
                Device.OpenUri(new Uri("instagram://user?username=drbeckyenenche"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://www.instagram.com/drbeckyenenche/"));
            }
        }

        public void youtubePage()
        {
            Device.OpenUri(new Uri("https://www.youtube.com/user/DrBeckyEnenche"));
        }
    }
}
