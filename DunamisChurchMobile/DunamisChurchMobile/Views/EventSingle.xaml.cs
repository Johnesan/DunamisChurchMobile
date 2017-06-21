using DunamisChurchMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DunamisChurchMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventSingle : ContentPage
    {
        public EventSingle()
        {
            InitializeComponent();
            BindingContext = new Event();
        }
    }
}
