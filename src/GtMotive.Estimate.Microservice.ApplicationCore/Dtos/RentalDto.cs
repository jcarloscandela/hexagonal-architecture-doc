using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Rent model dto.
    /// </summary>
    public class RentalDto
    {
        /// <summary>
        /// Gets or sets plate of the vehicle.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets mail of the Customer.
        /// </summary>
        public string CustomerMail { get; set; }

        /// <summary>
        /// Gets or sets StartDate of the rental.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate of the rental.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
