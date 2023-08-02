using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Return Vehicle Input.
    /// </summary>
    public class ReturnRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnRentalInput"/> class.
        /// </summary>
        /// <param name="plate">plate.</param>
        /// <param name="returnDate">returnDate.</param>
        public ReturnRentalInput(string plate, DateTime? returnDate)
        {
            Plate = plate;
            ReturnDate = returnDate;
        }

        /// <summary>
        /// Gets or sets plate.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets return date.
        /// </summary>
        public DateTime? ReturnDate { get; set; }
    }
}
