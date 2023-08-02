using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    /// <summary>
    /// Vehicle Repository.
    /// </summary>
    public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
        /// <summary>
        /// Get vehicle by plate.
        /// </summary>
        /// <param name="plate">input.</param>
        /// <returns>entity.</returns>
        Task<Vehicle> GetByPlateAsync(string plate);

        /// <summary>
        /// Get free vehicles.
        /// </summary>
        /// <param name="startDate">startdate.</param>
        /// <param name="endDate">endate.</param>
        /// <returns>freevehicles.</returns>
        Task<List<Vehicle>> GetFreeVehiclesAsync(DateTime startDate, DateTime endDate);
    }
}
