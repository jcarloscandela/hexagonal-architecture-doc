using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Unit Of Work. Should only be used by Use Cases.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets vehicle repository.
        /// </summary>
        IVehicleRepository VehicleRepository { get; }

        /// <summary>
        /// Gets rental repository.
        /// </summary>
        IRentalRepository RentalRepository { get; }

        /// <summary>
        /// Gets customer repository.
        /// </summary>
        ICustomerRepository CustomerRepository { get; }

        /// <summary>
        /// Applies all database changes.
        /// </summary>
        /// <returns>Number of affected rows.</returns>
        Task<int> Save();
    }
}
