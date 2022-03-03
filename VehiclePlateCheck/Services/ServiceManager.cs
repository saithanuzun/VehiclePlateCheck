using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using VehiclePlateCheck.Models;
using System.Text.Json;

namespace VehiclePlateCheck.Services
{
    public class ServiceManager
    {
        private HttpClient client;

        public ServiceManager()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", Constants.ApiKey);

        }
        public async Task<List<VehicleDataModel>> GetVehicleData(RequestBody _requestBody,bool isNewItem=false)
        {
            var Content = new StringContent(JsonConvert.SerializeObject(_requestBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync( Constants.Url, Content);
            var result  = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VehicleDataModel>>(result);



        }
        



    }
}
