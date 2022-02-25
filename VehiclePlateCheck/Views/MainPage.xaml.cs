using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VehiclePlateCheck.Views
{
    public partial class MainPage : ContentPage
    {
        private Page _detailsPage;

        public MainPage()
        {
            InitializeComponent();
            _detailsPage = new DetailsPage();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_detailsPage);
        }
    }
}
