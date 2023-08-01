using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Domain.Models;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.CQRS.Commands
{
    public class CreateVehicleCommand : IRequest<ICreateVehiclePresenter>
    {
        public CreateVehicleCommand(VehicleDto vehicleDto)
        {
            VehicleDto = vehicleDto;
        }

        public VehicleDto VehicleDto { get; set; }
    }
}
