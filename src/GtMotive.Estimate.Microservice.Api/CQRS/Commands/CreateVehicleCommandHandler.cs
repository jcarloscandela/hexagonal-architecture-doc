using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, ICreateVehiclePresenter>
    {
        private readonly IUseCase<CreateVehicleInput> _useCase;
        private readonly ICreateVehiclePresenter _presenter;

        public CreateVehicleCommandHandler(IUseCase<CreateVehicleInput> useCase, ICreateVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<ICreateVehiclePresenter> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            await _useCase.Execute(new CreateVehicleInput());
            return _presenter;
        }
    }
}
