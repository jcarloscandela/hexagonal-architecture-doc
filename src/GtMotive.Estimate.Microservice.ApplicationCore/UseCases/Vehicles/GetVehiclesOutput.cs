using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// GetVehiclesOutput.
    /// </summary>
    public sealed class GetVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">vehicles.</param>
        public GetVehiclesOutput(IEnumerable<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets vehicles list.
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; private set; }
    }
}
