using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Queries
{
    public class GetVehiclesQuery : IRequest<IGetVehiclesPresenter>
    {
        public GetVehiclesQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
