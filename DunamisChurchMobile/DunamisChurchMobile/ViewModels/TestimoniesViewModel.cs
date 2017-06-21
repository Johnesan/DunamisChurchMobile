using DunamisChurchMobile.Models;
using DunamisChurchMobile.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DunamisChurchMobile.ViewModels
{
    class TestimoniesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Testimony> _testimonies;
        public ObservableCollection<Testimony> Testimonies
        {
            get { return _testimonies; }
            set
            {
                _testimonies = value;
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

        public TestimoniesViewModel()
        {
            IsBusy = true;
            InitDataAsync();
        }
        public async Task InitDataAsync()
        {
            IsBusy = true;
            ChurchPlusApis service = new ChurchPlusApis();
            Testimonies = new ObservableCollection<Testimony>(await service.GetAllTestimonies());
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
