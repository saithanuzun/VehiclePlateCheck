using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePlateCheck.Models;
using VehiclePlateCheck.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehiclePlateCheck.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(VehicleDataModel _vehicleData)
        {
            InitializeComponent();
            BindingContext = new DetailsPageViewModel(_vehicleData);

        }
        

    }
}