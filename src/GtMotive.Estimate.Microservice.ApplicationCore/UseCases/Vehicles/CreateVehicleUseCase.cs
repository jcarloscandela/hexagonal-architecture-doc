using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Create Vehicle Use Case.
    /// </summary>
    public class CreateVehicleUseCase : IUseCase<CreateVehicleInput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOutputPortStandard<CreateVehicleOutput> _output;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="output">createVehicleOutputPort.</param>
        /// <param name="mapper">mapper.</param>
        public CreateVehicleUseCase(IUnitOfWork unitOfWork, IOutputPortStandard<CreateVehicleOutput> output, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _output = output;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>return.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException(nameof(input));
            }

            var entity = _mapper.Map<Vehicle>(input.VehicleDto);
            _unitOfWork.VehicleRepository.AddEntity(entity);
            await _unitOfWork.Save();

            _output.StandardHandle(new CreateVehicleOutput(_mapper.Map<VehicleDto>(entity)));
        }
    }
}
