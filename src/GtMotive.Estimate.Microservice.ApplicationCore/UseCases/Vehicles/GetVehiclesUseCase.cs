using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
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
            var result = await _unitOfWork.VehicleRepository.GetAllAsync();

            if (result.Count == 0)
            {
                _outputPort.NotFoundHandle("Vehicles not found");
            }
            else
            {
                _outputPort.StandardHandle(new GetVehiclesOutput(result));
            }
        }
    }
}
