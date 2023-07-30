using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    internal class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(GtMotiveContext context)
            : base(context)
        {
        }
    }
}
