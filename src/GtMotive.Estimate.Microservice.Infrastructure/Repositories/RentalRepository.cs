using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(GtMotiveContext context)
            : base(context)
        {
        }

        public async Task<bool> GetAnyRental(int idCustomer, DateTime startDate, DateTime endDate)
        {
            return await Context.Rentals.AnyAsync(rental => rental.CustomerId == idCustomer &&
                    rental.StartDate <= endDate && rental.EndDate >= startDate);
        }

        public async Task<Rental> GetCurrentRental(int idVehicle, DateTime returnDate)
        {
            return await Context.Rentals.FirstOrDefaultAsync(rental =>
                rental.VehicleId == idVehicle &&
                rental.StartDate <= returnDate &&
                rental.EndDate >= returnDate);
        }
    }
}
