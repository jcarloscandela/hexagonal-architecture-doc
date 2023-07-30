using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands
{
    public class CreateVehicleCommand : IRequest<ICreateVehiclePresenter>
    {
        public CreateVehicleCommand()
        {
        }
    }
}
