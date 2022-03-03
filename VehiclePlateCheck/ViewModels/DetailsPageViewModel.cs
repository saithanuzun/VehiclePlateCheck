using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VehiclePlateCheck.Models;

namespace VehiclePlateCheck.ViewModels
{
    public  class DetailsPageViewModel : INotifyPropertyChanged
    {
        private VehicleDataModel _vehicleData;

        public DetailsPageViewModel(VehicleDataModel _vehicleData)
        {
            this._vehicleData= _vehicleData;
        }

        public VehicleDataModel _vehicleDataModel { get => _vehicleData; set { _vehicleData = value; } }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
