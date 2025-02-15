﻿using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Queries
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, IGetVehiclesPresenter>
    {
        private readonly IUseCase<GetVehiclesInput> _useCase;
        private readonly IGetVehiclesPresenter _presenter;

        public GetVehiclesQueryHandler(IUseCase<GetVehiclesInput> useCase, IGetVehiclesPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IGetVehiclesPresenter> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _useCase.Execute(new GetVehiclesInput(request.StartDate, request.EndDate));

            return _presenter;
        }
    }
}
