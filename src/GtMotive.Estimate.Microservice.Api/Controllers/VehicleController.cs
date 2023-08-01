using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.CQRS.Commands;
using GtMotive.Estimate.Microservice.Api.CQRS.Queries;
using GtMotive.Estimate.Microservice.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVehicle(VehicleDto vehicleDto)
        {
            var request = new CreateVehicleCommand(vehicleDto);
            var presenter = await _mediator.Send(request);

            return presenter.ActionResult;
        }
    }
}
