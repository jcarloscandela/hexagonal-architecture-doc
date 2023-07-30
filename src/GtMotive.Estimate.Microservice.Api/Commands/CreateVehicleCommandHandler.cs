using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands
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
            var input = new CreateVehicleInput();
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
