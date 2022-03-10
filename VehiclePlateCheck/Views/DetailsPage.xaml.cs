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