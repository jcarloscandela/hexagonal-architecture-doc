using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    public class CreateVehicleCommand : IRequest<ICreateVehiclePresenter>
    {
        public CreateVehicleCommand()
        {
        }
    }
}
