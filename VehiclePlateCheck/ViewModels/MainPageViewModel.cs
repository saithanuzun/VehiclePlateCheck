using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VehiclePlateCheck.Models;
using VehiclePlateCheck.Services;
using VehiclePlateCheck.Views;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;

namespace VehiclePlateCheck.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; private set; }

        private ICommand _buttonClickedCommand;
        private String _plate;
        private bool _isRunning = false;
        private bool _isVisibleButton = true;
        private bool _isVisibleIndicator = false;



        public String Plate
        {
            get => _plate;
            set
            {
                _plate = value;
                OnPropertyChanged();
            }
        }
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        public bool IsVisibleButton
        {
            get => _isVisibleButton;
            set
            {
                _isVisibleButton = value;
                OnPropertyChanged();

            }
        }
        public bool IsVisibleIndicator
        {
            get => _isVisibleIndicator;
            set
            {
                _isVisibleIndicator = value;
                OnPropertyChanged();
            }
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

        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            _buttonClickedCommand = new Command(ButtonClicked);
        }


        private ServiceManager _serviceManager = new ServiceManager();
        public async void ButtonClicked()
        {
            void ViewControl()
            {
                IsRunning = !IsRunning;
                IsVisibleIndicator = !IsVisibleIndicator;
                IsVisibleButton = !IsVisibleButton;

            }
            ViewControl();
            await Task.Delay(1000);

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Information", "No Internet Connection", "OK");
                ViewControl();
                return;
            }
            else if (_plate == null)
            {
                await App.Current.MainPage.DisplayAlert("Information", "Please Enter a Valid Registration", "OK");
                ViewControl();
                return;
            }
            else
            {
                RequestBody _requestBody = new RequestBody();
                _requestBody.RegistrationNumber = _plate;

                var VehicleDataModel = await _serviceManager.GetVehicleDataAsync(_requestBody);

                if (VehicleDataModel == null)
                {
                    await App.Current.MainPage.DisplayAlert("Information", "Vehicle Has Not Been Found", "OK");
                    ViewControl();
                    return;

                }
                else
                {
                    await Navigation.PushAsync(new DetailsPage(VehicleDataModel));
                    ViewControl();
                }              
            }         
        }



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }


    }
}
