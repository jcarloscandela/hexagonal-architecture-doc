using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    internal class ReturnRentalCommandHandler : IRequestHandler<ReturnRentalCommand, IReturnRentalPresenter>
    {
        private readonly IUseCase<ReturnRentalInput> _useCase;
        private readonly IReturnRentalPresenter _presenter;

        public ReturnRentalCommandHandler(IUseCase<ReturnRentalInput> useCase, IReturnRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IReturnRentalPresenter> Handle(ReturnRentalCommand request, CancellationToken cancellationToken)
        {
            await _useCase.Execute(new ReturnRentalInput(request?.Plate, request?.ReturnDate));
            return _presenter;
        }
    }
}
