using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VehiclePlateCheck.Views;

[assembly: ExportFont("UKNumberPlate.ttf")]
[assembly: ExportFont("UKNumberPlate.ttf", Alias = "NumberPlate")]

namespace VehiclePlateCheck
{
    public partial class App : Application
    {

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
