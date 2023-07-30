using System.Collections.Generic;
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
        private readonly IOutputPortStandard<GetVehiclesOutput> _output;
        private readonly IGetVehiclesOutputPortNotFound _notFound;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="output">Output. </param>
        /// <param name="notFound">Notfound. </param>
        public GetVehiclesUseCase(IUnitOfWork unitOfWork, IOutputPortStandard<GetVehiclesOutput> output, IGetVehiclesOutputPortNotFound notFound)
        {
            _unitOfWork = unitOfWork;
            _output = output;
            _notFound = notFound;
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
                _notFound.NotFoundHandle("Vehicles not found");
                return;
            }

            _output.StandardHandle(new GetVehiclesOutput(result));
        }
    }
}
