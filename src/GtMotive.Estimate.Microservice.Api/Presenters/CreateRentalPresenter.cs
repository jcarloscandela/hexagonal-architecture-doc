using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public sealed class CreateRentalPresenter : ICreateRentalPresenter, ICreateRentalOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void BadRequestHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(CreateRentalOutput response)
        {
            ActionResult = new OkObjectResult(response?.RentalDto);
        }
    }
}
