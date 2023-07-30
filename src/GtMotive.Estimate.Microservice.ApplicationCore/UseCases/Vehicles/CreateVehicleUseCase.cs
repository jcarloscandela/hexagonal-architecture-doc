using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Create Vehicle Use Case.
    /// </summary>
    public class CreateVehicleUseCase : IUseCase<CreateVehicleInput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPortStandard<CreateVehicleOutput> _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="output">createVehicleOutputPort.</param>
        public CreateVehicleUseCase(IUnitOfWork unitOfWork, IOutputPortStandard<CreateVehicleOutput> output)
        {
            _unitOfWork = unitOfWork;
            _output = output;
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>return.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            _unitOfWork.VehicleRepository.AddEntity(new Domain.Models.Vehicle());
            await _unitOfWork.Save();

            _output.StandardHandle(new CreateVehicleOutput());
        }
    }
}
