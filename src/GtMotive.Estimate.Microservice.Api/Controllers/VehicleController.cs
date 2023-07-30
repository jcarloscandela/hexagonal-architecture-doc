using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle()
        {
            var request = new CreateVehicleRequest();
            var presenter = await _mediator.Send(request);

            return presenter.ActionResult;
        }
    }
}
