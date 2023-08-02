using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    public class CreateRentalCommand : IRequest<ICreateRentalPresenter>
    {
        public CreateRentalCommand(RentalDto rentalDto)
        {
            RentalDto = rentalDto;
        }

        public RentalDto RentalDto { get; set; }
    }
}
