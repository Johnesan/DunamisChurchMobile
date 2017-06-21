using DunamisChurchMobile.Models;
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
        private ObservableCollection<SeedOfDestinyRead> _seedOfDestinies;
        public ObservableCollection<SeedOfDestinyRead> SeedOfDestinies
        {
            get
            {  return _seedOfDestinies; }
            set
            {
                _seedOfDestinies = value;
                OnPropertyChanged();
            }
        }

        public SeedOfDestinyReadViewModel()
        {
            SeedOfDestinies = new ObservableCollection<SeedOfDestinyRead>
            {
                new SeedOfDestinyRead{ Title="I am Rich", Date=DateTime.Parse("12/03/2017"), Scripture="Revelation 3:17 - You say, ‘I am rich; I have acquired wealth and do not need a thing.’ But you do not realize that you are wretched, pitiful, poor, blind and naked. "},
                new SeedOfDestinyRead{ Title="The Lord Sends Poverty and Riches", Date=DateTime.Parse("11/03/2017"), Scripture="1 Samuel 2:6-7 - The LORD brings death and makes alive; he brings down to the grave and raises up. The LORD sends poverty and wealth; he humbles and he exalts."}
            };
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
