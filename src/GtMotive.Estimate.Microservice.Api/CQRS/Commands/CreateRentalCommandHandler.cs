using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    internal class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, ICreateRentalPresenter>
    {
        private readonly IUseCase<CreateRentalInput> _useCase;
        private readonly ICreateRentalPresenter _presenter;

        public CreateRentalCommandHandler(IUseCase<CreateRentalInput> useCase, ICreateRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<ICreateRentalPresenter> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            await _useCase.Execute(new CreateRentalInput(request?.RentalDto));
            return _presenter;
        }
    }
}
