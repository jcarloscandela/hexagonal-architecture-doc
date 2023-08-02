using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateRental
{
    /// <summary>
    /// Create Rental Use Case.
    /// </summary>
    internal class CreateRentalUseCase : IUseCase<CreateRentalInput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateRentalOutputPort _output;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="output">createVehicleOutputPort.</param>
        /// <param name="mapper">mapper.</param>
        public CreateRentalUseCase(IUnitOfWork unitOfWork, ICreateRentalOutputPort output, IMapper mapper)
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
        public async Task Execute(CreateRentalInput input)
        {
            if (input == null || input.RentalDto == null)
            {
                _output.BadRequestHandle("Data cannot be null");
                return;
            }

            if (input.RentalDto.StartDate > input.RentalDto.EndDate)
            {
                _output.BadRequestHandle("Start date cannot be greater than end date");
                return;
            }

            var customer = await _unitOfWork.CustomerRepository.GetByEmailAsync(input.RentalDto.CustomerMail);

            if (customer == null)
            {
                _output.BadRequestHandle($"Customer with email {input.RentalDto.CustomerMail} doesn't exist.");
                return;
            }

            var vehicle = await _unitOfWork.VehicleRepository.GetByPlateAsync(input.RentalDto.Plate);
            if (vehicle == null)
            {
                _output.BadRequestHandle($"Vehicle with plate {input.RentalDto.Plate} doesn't exist.");
                return;
            }

            var hasRentals = await _unitOfWork.RentalRepository.GetAnyRental(customer.Id, input.RentalDto.StartDate, input.RentalDto.EndDate);

            if (hasRentals)
            {
                _output.BadRequestHandle($"Customer with email {input.RentalDto.CustomerMail} already has a rental in the selected dates.");
                return;
            }

            var entity = _mapper.Map<Rental>(input.RentalDto);
            entity.CustomerId = customer.Id;
            entity.VehicleId = vehicle.Id;
            _unitOfWork.RentalRepository.AddEntity(entity);
            await _unitOfWork.Save();

            _output.StandardHandle(new CreateRentalOutput(input.RentalDto));
        }
    }
}
