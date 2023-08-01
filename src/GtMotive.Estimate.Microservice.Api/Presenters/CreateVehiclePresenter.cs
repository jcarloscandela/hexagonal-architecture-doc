using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class CreateVehiclePresenter : ICreateVehiclePresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(CreateVehicleOutput response)
        {
            var vehicleDto = response?.VehicleDto;

            ActionResult = new OkObjectResult(vehicleDto);
        }
    }
}
