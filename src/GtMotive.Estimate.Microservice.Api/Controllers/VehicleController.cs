using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.CQRS.Commands;
using GtMotive.Estimate.Microservice.Api.CQRS.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var request = new GetVehiclesQuery();
            var presenter = await _mediator.Send(request);

            return presenter.ActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle()
        {
            var request = new CreateVehicleCommand();
            var presenter = await _mediator.Send(request);

            return presenter.ActionResult;
        }
    }
}
