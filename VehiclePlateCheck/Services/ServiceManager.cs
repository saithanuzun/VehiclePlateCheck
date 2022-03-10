using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VehiclePlateCheck.Models;

namespace VehiclePlateCheck.Services
{
    public class ServiceManager
    {
        private HttpClient httpClient;

        public ServiceManager()
        {
            httpClient = new HttpClient();

        }
        public async Task<VehicleDataModel> GetVehicleDataAsync(RequestBody _requestBody)
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), Constants.Url);
            request.Headers.TryAddWithoutValidation("x-api-key", Constants.ApiKey);
            request.Content = new StringContent("{\"registrationNumber\": \"" + _requestBody.registrationNumber + "\"}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                VehicleDataModel _vehicleData = JsonConvert.DeserializeObject<VehicleDataModel>(stringResult);

                return _vehicleData;

            }
            else
            {
                return null;
            }
        }

    }
}
