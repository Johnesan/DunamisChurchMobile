using DunamisChurchMobile.Models;
using DunamisChurchMobile.Services;
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
            InitDataAsync();
        }
        public async Task InitDataAsync()
        {
            IsBusy = true;
            ChurchPlusApis service = new ChurchPlusApis();            
            Events = new ObservableCollection<Event>(await service.GetAllEvents());
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
