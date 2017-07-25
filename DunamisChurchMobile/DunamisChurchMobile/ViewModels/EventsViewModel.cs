using DunamisChurchMobile.Databases;
using DunamisChurchMobile.Models;
using DunamisChurchMobile.Services;
using Plugin.Connectivity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DunamisChurchMobile.ViewModels
{
    class EventsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set
            {
                _events = value;
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

        public EventsViewModel()
        {
            IsBusy = true;
            Events = new ObservableCollection<Event>(App.database.GetAllEvents()); 
            InitDataAsync();
        }
        public async Task InitDataAsync()
        {           
            if (!CrossConnectivity.Current.IsConnected)
            {
                IsBusy = false; 
                return;
            }
            ChurchPlusApis service = new ChurchPlusApis();
            var UpdatedEvents = await service.GetAllEvents();
            App.database.AddUpdatedEvents(UpdatedEvents);
            Events = new ObservableCollection<Event>(App.database.GetAllEvents());
            IsBusy = false;
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
