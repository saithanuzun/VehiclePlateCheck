using VehiclePlateCheck.ViewModels;
using Xamarin.Forms;

namespace VehiclePlateCheck.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
           
        }

    }
}
