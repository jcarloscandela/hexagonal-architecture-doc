using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Models;
using Newtonsoft.Json;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests
{
    public class VehicleControllerFunctionalTests : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "https://localhost:15743";

        public VehicleControllerFunctionalTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task CreateVehicleReturnsOk()
        {
            var uri = new Uri(_baseAddress + "/api/Vehicle");

            var vehicleDto = new VehicleDto
            {
                Brand = "TestBrand",
                Model = "TestModel",
                Plate = "ABC123",
                ManufacturingDate = DateTime.UtcNow
            };

            using var content = new StringContent(JsonConvert.SerializeObject(vehicleDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
        }
    }
}
