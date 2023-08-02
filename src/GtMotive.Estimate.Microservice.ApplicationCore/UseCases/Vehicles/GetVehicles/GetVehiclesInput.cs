using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles
{
    /// <summary>
    /// Get Vehicles Input.
    /// </summary>
    public class GetVehiclesInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehiclesInput"/> class.
        /// </summary>
        /// <param name="startDate">startdate.</param>
        /// <param name="endDate">endDate.</param>
        public GetVehiclesInput(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Gets or sets start date.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets end date.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
