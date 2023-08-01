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

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Rentals)
                .HasForeignKey(r => r.VehicleId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId);

            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle() { Id = 1, Brand = "Opel", Model = "Corsa", Plate = "9999ABC", ManufacturingDate = DateTime.Now });

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, Email = "jccandelabordera@gmail.com" });
        }
    }
}
