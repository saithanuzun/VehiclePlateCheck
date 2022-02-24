using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclePlateCheck.Model
{
    internal class VehicleDataModel
    {
        public string registrationNumber { get; set; }
        public int co2Emissions { get; set; }
        public int engineCapacity { get; set; }
        public bool markedForExport { get; set; }
        public string fuelType { get; set; }
        public string motStatus { get; set; }
        public int revenueWeight { get; set; }
        public string colour { get; set; }
        public string make { get; set; }
        public string typeApproval { get; set; }
        public int yearOfManufacture { get; set; }
        public string taxDueDate { get; set; }
        public string taxStatus { get; set; }
        public string dateOfLastV5CIssued { get; set; }
        public string motExpiryDate { get; set; }
        public string wheelplan { get; set; }
        public string monthOfFirstRegistration { get; set; }

    }
}
