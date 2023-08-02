using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Customer repository.
    /// </summary>
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        /// <summary>
        /// Get customer by email.
        /// </summary>
        /// <param name="email">input.</param>
        /// <returns>entity.</returns>
        Task<Customer> GetByEmailAsync(string email);
    }
}
