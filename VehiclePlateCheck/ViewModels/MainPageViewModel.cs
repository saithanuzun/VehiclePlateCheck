using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VehiclePlateCheck.Models;
using VehiclePlateCheck.Services;
using VehiclePlateCheck.Views;
using Xamarin.Forms;

namespace VehiclePlateCheck.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get;private  set; }

        private ICommand _buttonClickedCommand;
        private String _plate;
        private ServiceManager _serviceManager = new ServiceManager();
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            _buttonClickedCommand = new Command(ButtonClicked);
        }
        public ICommand ButtonClickedCommand
        {
            get
            {
                return _buttonClickedCommand;
            }
            set
            {
                _buttonClickedCommand = value;
            }

        }
        public String Plate { get => _plate; set { _plate = value; } }

        public async void ButtonClicked()
        {
            string _plate=this._plate.Trim();
            Console.WriteLine(_plate);
            RequestBody _requestBody = new RequestBody();
            _requestBody.RegistrationNumber = _plate;

            var VehicleDataModel =await _serviceManager.GetVehicleDataAsync(_requestBody);    
            if(VehicleDataModel==null)
            {
                return;

            }
            await Navigation.PushAsync(new DetailsPage(VehicleDataModel));

        }
    
        

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
