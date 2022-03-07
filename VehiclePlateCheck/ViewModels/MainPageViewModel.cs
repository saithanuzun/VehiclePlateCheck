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
using VehiclePlateCheck.Database;
using System.Collections.ObjectModel;


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
        private ObservableCollection<DatabaseModel> _searches;
        private DatabaseModel _selectedItem;

        public DatabaseModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    HandleSelectedItem();
                }
            }
        }

        public ObservableCollection<DatabaseModel> Searches
        {
            get
            {
                if (_searches == null)
                {
                    _searches = new ObservableCollection<DatabaseModel>(App.DatabaseManager.GetDatabaseAsync().Result);
                }
                return _searches;
            }
            set
            {
                if (value != _searches)
                {
                    _searches = value;
                }
            }
        }
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
                if (_buttonClickedCommand == null)
                {
                    _buttonClickedCommand = new Command(ButtonClicked);
                }
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
        }
        private void HandleSelectedItem()
        {
            Plate = SelectedItem.registrationNumber;
        }
        public async void ButtonClicked()
        {
            void ActivityIndicatorController()
            {
                IsRunning = !IsRunning;
                IsVisibleIndicator = !IsVisibleIndicator;
                IsVisibleButton = !IsVisibleButton;
            }
            ActivityIndicatorController();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Information", "No Internet Connection", "OK");
            }
            else if (Plate == null)
            {
                await App.Current.MainPage.DisplayAlert("Information", "Please Enter a Valid Registration", "OK");
            }
            else
            {
                ServiceManager _serviceManager = new ServiceManager();

                RequestBody _requestBody = new RequestBody { registrationNumber = Plate };

                var VehicleDataModel = await _serviceManager.GetVehicleDataAsync(_requestBody);

                if (VehicleDataModel == null)
                {
                    await App.Current.MainPage.DisplayAlert("Information", "Vehicle Has Not Been Found", "OK");
                }
                else
                {
                    bool isExist = false;
                    foreach (var m in App.DatabaseManager.GetDatabaseAsync().Result)
                    {
                        if (m.registrationNumber == Plate)
                        {
                            isExist = true;
                        }
                    }
                    if (!isExist)
                    {
                        DatabaseModel model = new DatabaseModel { registrationNumber = Plate };
                        await App.DatabaseManager.SaveDatabaseAsync(model);
                        Searches.Add(model);
                    }
                    await Navigation.PushAsync(new DetailsPage(VehicleDataModel));
                }
            }
            ActivityIndicatorController();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }


    }
}
