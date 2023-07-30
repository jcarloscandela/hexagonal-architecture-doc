using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        public CreateVehicleRequest()
        {
        }
    }
}
