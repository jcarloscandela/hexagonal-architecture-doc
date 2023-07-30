using GtMotive.Estimate.Microservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistance
{
    public class GtMotiveContext : DbContext
    {
        public GtMotiveContext(DbContextOptions<GtMotiveContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
