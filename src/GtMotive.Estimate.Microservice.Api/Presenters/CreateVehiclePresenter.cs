using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class CreateVehiclePresenter : ICreateVehiclePresenter, IOutputPortStandard<CreateVehicleOutput>
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CreateVehicleOutput response)
        {
            var vehicleDto = response?.Vehicle;

            ActionResult = new OkObjectResult(vehicleDto);
        }
    }
}
