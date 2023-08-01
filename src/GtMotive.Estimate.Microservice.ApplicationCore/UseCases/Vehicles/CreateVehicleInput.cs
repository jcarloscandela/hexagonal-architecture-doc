using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Create Vehicle Input.
    /// </summary>
    public class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleDto">Dto.</param>
        public CreateVehicleInput(VehicleDto vehicleDto)
        {
            VehicleDto = vehicleDto;
        }

        /// <summary>
        /// Gets or sets vehicle.
        /// </summary>
        public VehicleDto VehicleDto { get; set; }
    }
}
