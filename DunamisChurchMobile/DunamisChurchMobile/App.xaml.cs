using DunamisChurchMobile.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DunamisChurchMobile
{
    public partial class App : Application
    {
        private static DunamisDB _database;
        public static DunamisDB database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DunamisDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("dunamisdb.db3"));
                }
                return _database;
            }
        }
               
        public App()
        {
            InitializeComponent();

            //MainPage = new DunamisChurchMobile.MainPage();
            MainPage = new RootPage();
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
