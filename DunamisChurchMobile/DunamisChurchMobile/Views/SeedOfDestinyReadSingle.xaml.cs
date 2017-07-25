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
    public partial class SeedOfDestinyReadSingle : ContentPage
    {
        public SeedOfDestinyReadSingle(string msg)
        {
            InitializeComponent();
            BindingContext = new Models.SeedOfDestiny();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html>  
                                    <head>
                                        <style>
                                            p    {color: red; font-size:17px;}
                                        </style>
                                     </head> 
                                     <body>"
                                        + msg.ToString() +
                                     @"</body> </html>";
            webview.Source = htmlSource;
        }
    }
}
