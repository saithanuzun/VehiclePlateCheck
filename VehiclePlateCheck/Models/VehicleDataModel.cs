using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VehiclePlateCheck.Models
{
    public class VehicleDataModel
    {

        [JsonProperty("registrationNumber")]
            public string registrationNumber { get; set; }

        [JsonProperty("co2Emissions")]
            public int co2Emissions { get; set; }

        [JsonProperty("engineCapacity")]
            public int engineCapacity { get; set; }

        [JsonProperty("markedForExport")]
            public bool markedForExport { get; set; }

        [JsonProperty("fuelType")]
           public string fuelType { get; set; }

        [JsonProperty("motStatus")]
           public string motStatus { get; set; }

        [JsonProperty("revenueWeight")]
            public int revenueWeight { get; set; }

        [JsonProperty("colour")]
            public string colour { get; set; }

        [JsonProperty("make")]
            public string make { get; set; }

        [JsonProperty("typeApproval")]
            public string typeApproval { get; set; }

        [JsonProperty("yearOfManufacture")]
            public int yearOfManufacture { get; set; }

        [JsonProperty("taxDueDate")]
            public string taxDueDate { get; set; }

        [JsonProperty("taxStatus")]
            public string taxStatus { get; set; }

        [JsonProperty("dateOfLastV5CIssued")]
            public string dateOfLastV5CIssued { get; set; }

        [JsonProperty("motExpiryDate")]
            public string motExpiryDate { get; set; }

        [JsonProperty("wheelplan")]
            public string wheelplan { get; set; }

        [JsonProperty("monthOfFirstRegistration")]
            public string monthOfFirstRegistration { get; set; }

    }
}
