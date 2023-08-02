using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    internal class ReturnRentalCommand : IRequest<IReturnRentalPresenter>
    {
        public ReturnRentalCommand(string plate, DateTime returnDate)
        {
            Plate = plate;
            ReturnDate = returnDate;
        }

        public string Plate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
