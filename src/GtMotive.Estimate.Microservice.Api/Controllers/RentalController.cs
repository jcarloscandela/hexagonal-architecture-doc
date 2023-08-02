using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.CQRS.Commands;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRental(RentalDto rentDto)
        {
            var request = new CreateRentalCommand(rentDto);
            var presenter = await _mediator.Send(request);

            return presenter.ActionResult;
        }
    }
}
