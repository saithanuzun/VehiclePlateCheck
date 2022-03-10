using System.ComponentModel;
using System.Runtime.CompilerServices;
using VehiclePlateCheck.Models;

namespace VehiclePlateCheck.ViewModels
{
    public class DetailsPageViewModel : INotifyPropertyChanged
    {
        private VehicleDataModel _vehicleData;
        public VehicleDataModel _vehicleDataModel
        {
            get => _vehicleData;
            set
            {
                _vehicleData = value;
                OnPropertyChanged();
            }
        }

        public DetailsPageViewModel(VehicleDataModel _vehicleData)
        {
            this._vehicleData = _vehicleData;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
