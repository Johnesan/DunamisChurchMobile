using DunamisChurchMobile.Models;
using DunamisChurchMobile.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DunamisChurchMobile.ViewModels
{
    class SeedOfDestinyReadViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SeedOfDestiny> _seedOfDestinies;
        public ObservableCollection<SeedOfDestiny> SeedOfDestinies
        {
            get
            {  return _seedOfDestinies; }
            set
            {
                _seedOfDestinies = value;
                OnPropertyChanged();
            }
        }

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

        public SeedOfDestinyReadViewModel()
        {
            InitAsync();
        }
        public async Task InitAsync()
        {
            try
            {
                IsBusy = true;
                SeedOfDestinies = new ObservableCollection<SeedOfDestiny>(App.database.GetAllSeedOfDestinies());
                if (!CrossConnectivity.Current.IsConnected)
                {
                    IsBusy = false;
                    return;
                }
                ChurchPlusApis service = new ChurchPlusApis();
                var UpdatedSeedOfDestinies = await service.GetSeedOfDestinies();
                App.database.AddUpdatedSeedOfDestinies(UpdatedSeedOfDestinies);
                SeedOfDestinies = new ObservableCollection<SeedOfDestiny>(App.database.GetAllSeedOfDestinies());
                foreach (SeedOfDestiny seedOfDestiny in UpdatedSeedOfDestinies)
                {
                    if (seedOfDestiny.created > DateTime.Now)
                    {
                        SeedOfDestinies.Remove(seedOfDestiny);
                    }
                }               
            }
            catch(Exception e)
            {

            }
            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
