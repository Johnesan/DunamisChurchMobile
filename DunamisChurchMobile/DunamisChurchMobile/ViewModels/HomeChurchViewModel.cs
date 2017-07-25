using DunamisChurchMobile.Models;
using DunamisChurchMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DunamisChurchMobile.ViewModels
{
    class HomeChurchViewModel : INotifyPropertyChanged
    {
        private INavigation Navigation;
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        private bool _nothingFound;
        public bool NothingFound
        {
            get { return _nothingFound; }
            set
            {
                _nothingFound = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<HomeChurch> _homeChurches;
        public ObservableCollection<HomeChurch> HomeChurches
        {
            get { return _homeChurches; }
            set
            {
                _homeChurches = value;
                OnPropertyChanged();
            }
        }
        //public ICommand SearchHomeChurchesCommand { get; set; }
        //public ICommand ViewAllHomeChurchesCommand { get; set; }
        ///public static string SearchString;

    
        public HomeChurchViewModel(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                InitSearchAsync(searchString);
            }
            else
            {
                InitAllAsync();
            }
        }
        public async void InitSearchAsync(string name)
        {
            NothingFound = false;
            IsBusy = true;
            ChurchPlusApis service = new ChurchPlusApis();
            HomeChurches = new ObservableCollection<HomeChurch>(await service.SearchHomeChurches(name));
            //HomeChurches = new ObservableCollection<HomeChurch>(await service.GetAllHomeChurches());
            
            IsBusy = false;
            if (HomeChurches.Count == 0)
            {
                NothingFound = true;
            }
        }

     public async void InitAllAsync()
        {
            IsBusy = true;
            ChurchPlusApis service = new ChurchPlusApis();
            HomeChurches = new ObservableCollection<HomeChurch>(await service.GetAllHomeChurches());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
