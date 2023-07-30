using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
    }
}
