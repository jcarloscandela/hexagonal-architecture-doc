using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class GetVehiclesPresenter : IGetVehiclesPresenter, IOutputPortStandard<GetVehiclesOutput>, IGetVehiclesOutputPortNotFound
    {
        public IActionResult ActionResult { get; private set; }

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
