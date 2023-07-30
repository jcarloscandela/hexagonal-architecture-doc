using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle() { Id = 1, Brand = "Opel", Model = "Corsa", Plate = "9999ABC", ManufacturingDate = DateTime.Now });
        }
    }
}
