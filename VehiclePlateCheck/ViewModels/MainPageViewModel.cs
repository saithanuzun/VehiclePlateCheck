using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VehiclePlateCheck.Views;
using Xamarin.Forms;

namespace VehiclePlateCheck.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get;private  set; }

        private ICommand _buttonClickedCommand;
        private String _plate;
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
            
            await Navigation.PushAsync(new DetailsPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
