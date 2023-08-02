using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Return Rental Use Case.
    /// </summary>
    internal class ReturnRentalUseCase : IUseCase<ReturnRentalInput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReturnRentalOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnRentalUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="output">ReturnVehicleOutputPort.</param>
        /// <param name="mapper">mapper.</param>
        public ReturnRentalUseCase(IUnitOfWork unitOfWork, IReturnRentalOutputPort output)
        {
            _unitOfWork = unitOfWork;
            _outputPort = output;
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>return.</returns>
        public async Task Execute(ReturnRentalInput input)
        {
            if (string.IsNullOrEmpty(input.Plate))
            {
                _outputPort.BadRequestHandle("Plate cannot be null or empty.");
                return;
            }

            if (!input.ReturnDate.HasValue || input.ReturnDate == default(DateTime))
            {
                _outputPort.BadRequestHandle("StartDate cannot be null or empty");
                return;
            }

            var vehicle = await _unitOfWork.VehicleRepository.GetByPlateAsync(input.Plate);

            if (vehicle == null)
            {
                _outputPort.BadRequestHandle("Vehicle doesn't exist.");
                return;
            }

            var rental = await _unitOfWork.RentalRepository.GetCurrentRental(vehicle.Id, input.ReturnDate.Value);

            if (rental == null)
            {
                _outputPort.BadRequestHandle("Vehicle is not rented right now.");
                return;
            }

            rental.EndDate = input.ReturnDate.Value;
            _unitOfWork.RentalRepository.UpdateEntity(rental);
            await _unitOfWork.Save();

            _outputPort.StandardHandle(new ReturnRentalOutput());
        }
    }
}
