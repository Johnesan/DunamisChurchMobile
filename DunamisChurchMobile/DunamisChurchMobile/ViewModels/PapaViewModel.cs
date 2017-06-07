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
    class PapaViewModel : BaseViewModel
    {
        private INavigation Navigation;
        public ICommand facebookCommand { get; private set; }
        public ICommand twitterCommand { get; private set; }
        public ICommand instagramCommand { get; set; }
        public ICommand youtubeCommand { get; set; }

        public PapaViewModel(INavigation _Navigation)
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
                Device.OpenUri(new Uri("fb://page/211471295567785"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://www.facebook.com/drpastorpaulenenche/"));
            }
        }

        public void twitterPage()
        {
            try
            {
                Device.OpenUri(new Uri("twitter://user?user_id=584924489"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://twitter.com/DrPaulEnenche"));
            }
        }

        public void instagramPage()
        {
            try
            {
                Device.OpenUri(new Uri("instagram://user?username=drpastorpaulenenche"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://www.instagram.com/drpastorpaulenenche/"));
            }
        }

        public void youtubePage()
        {
            Device.OpenUri(new Uri("https://www.youtube.com/user/DrPastorPaulEnenche"));
        }
    }
}
