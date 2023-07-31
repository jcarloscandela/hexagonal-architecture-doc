using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Queries
{
    public class GetVehiclesQuery : IRequest<IGetVehiclesPresenter>
    {
        public GetVehiclesQuery()
        {
        }
    }
}
