using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles
{
    /// <summary>
    /// Get Vehicles Use Case.
    /// </summary>
    public class GetVehiclesUseCase : IUseCase<GetVehiclesInput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="outputPort">Output. </param>
        public GetVehiclesUseCase(IUnitOfWork unitOfWork, IGetVehiclesOutputPort outputPort)
        {
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>return.</returns>
        public async Task Execute(GetVehiclesInput input)
        {
            if (input == null)
            {
                _outputPort.BadRequestHandle("Data cannot be null.");
                return;
            }

            if (!input.StartDate.HasValue || input.StartDate == default(DateTime))
            {
                _outputPort.BadRequestHandle("Start date cannot be null or empty.");
                return;
            }

            if (!input.EndDate.HasValue || input.EndDate == default(DateTime))
            {
                _outputPort.BadRequestHandle("End date cannot be null or empty.");
                return;
            }

            if (input.StartDate > input.EndDate)
            {
                _outputPort.BadRequestHandle("StartDate cannot be bigger than EndDate");
                return;
            }

            var result = await _unitOfWork.VehicleRepository.GetFreeVehiclesAsync(input.StartDate.Value, input.EndDate.Value);

            if (result.Count == 0)
            {
                _outputPort.NotFoundHandle("Vehicles not found for that period of time.");
            }
            else
            {
                _outputPort.StandardHandle(new GetVehiclesOutput(result));
            }
        }
    }
}
