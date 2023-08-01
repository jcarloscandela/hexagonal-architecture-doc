using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Create Vehicle Output.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleDto">dto.</param>
        public CreateVehicleOutput(VehicleDto vehicleDto)
        {
            VehicleDto = vehicleDto;
        }

        /// <summary>
        /// Gets created vehicle.
        /// </summary>
        public VehicleDto VehicleDto { get; }
    }
}
