using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class GetVehiclesPresenter : IGetVehiclesPresenter, IGetVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(GetVehiclesOutput response)
        {
            ActionResult = new OkObjectResult(response?.Vehicles);
        }
    }
}
