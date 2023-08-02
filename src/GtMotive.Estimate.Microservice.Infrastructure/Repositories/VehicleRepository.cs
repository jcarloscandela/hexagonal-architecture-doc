using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    internal class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(GtMotiveContext context)
            : base(context)
        {
        }

        public async Task<Vehicle> GetByPlateAsync(string plate)
        {
            return await Context.Vehicles.FirstOrDefaultAsync(x => x.Plate == plate);
        }

        public async Task<List<Vehicle>> GetFreeVehiclesAsync(DateTime startDate, DateTime endDate)
        {
            // Get the list of vehicles that do not have any rentals within the given date range.
            var freeVehicles = await Context.Vehicles
                .Where(vehicle => !Context.Rentals
                    .Any(rental => rental.VehicleId == vehicle.Id && rental.StartDate <= endDate && rental.EndDate >= startDate))
                .ToListAsync();

            return freeVehicles;
        }
    }
}
