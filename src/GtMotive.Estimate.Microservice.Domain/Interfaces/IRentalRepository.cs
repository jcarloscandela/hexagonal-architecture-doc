using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Rental Repository.
    /// </summary>
    public interface IRentalRepository : IAsyncRepository<Rental>
    {
        /// <summary>
        /// Get rentals between dates.
        /// </summary>
        /// <param name="idCustomer">idCustomer.</param>
        /// <param name="startDate">startdate.</param>
        /// <param name="endDate">dateTime.</param>
        /// <returns>If there is a rental between the dates.</returns>
        Task<bool> GetAnyRental(int idCustomer, DateTime startDate, DateTime endDate);
    }
}
