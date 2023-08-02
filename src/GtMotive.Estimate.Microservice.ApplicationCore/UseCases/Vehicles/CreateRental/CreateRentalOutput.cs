using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateRental
{
    /// <summary>
    /// Create Rental Output.
    /// </summary>
    public class CreateRentalOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalOutput"/> class.
        /// </summary>
        /// <param name="rentalDto">Rental dto.</param>
        public CreateRentalOutput(RentalDto rentalDto)
        {
            RentalDto = rentalDto;
        }

        /// <summary>
        /// Gets created rental.
        /// </summary>
        public RentalDto RentalDto { get; }
    }
}
