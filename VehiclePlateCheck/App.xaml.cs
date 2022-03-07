using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VehiclePlateCheck.Views;
using VehiclePlateCheck.Database;
using System.IO;

[assembly: ExportFont("UKNumberPlate.ttf")]
[assembly: ExportFont("UKNumberPlate.ttf", Alias = "NumberPlate")]

namespace VehiclePlateCheck
{
    public partial class App : Application
    {
        private static DatabaseManager _databaseManager;
        public static DatabaseManager DatabaseManager
        {
            get
            {
                if (_databaseManager == null)
                {
                    _databaseManager = new DatabaseManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Searches.db1"));

                }
                return _databaseManager;
            }
        }


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
              

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
