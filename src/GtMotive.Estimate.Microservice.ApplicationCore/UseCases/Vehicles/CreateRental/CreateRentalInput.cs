using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateRental
{
    /// <summary>
    /// Create Rental Input.
    /// </summary>
    public class CreateRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalInput"/> class.
        /// </summary>
        /// <param name="rentalDto">Dto.</param>
        public CreateRentalInput(RentalDto rentalDto)
        {
            RentalDto = rentalDto;
        }

        /// <summary>
        /// Gets or sets vehicle.
        /// </summary>
        public RentalDto RentalDto { get; set; }
    }
}
