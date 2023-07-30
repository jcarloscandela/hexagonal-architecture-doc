using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Queries
{
    public class GetVehiclesQuery : IRequest<IGetVehiclesPresenter>
    {
        public GetVehiclesQuery()
        {
        }
    }
}
