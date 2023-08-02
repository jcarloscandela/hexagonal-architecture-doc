using System;
using System.Linq;
using GtMotive.Estimate.Microservice.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests
{
    public class GtMotiveContextTests
    {
        private readonly DbContextOptions<GtMotiveContext> _options;

        public GtMotiveContextTests()
        {
            _options = new DbContextOptionsBuilder<GtMotiveContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public void TestSeedData()
        {
            using var context = new GtMotiveContext(_options);

            context.Database.EnsureCreated();

            var vehicle = context.Vehicles.FirstOrDefault(v => v.Id == 1);
            var customer = context.Customers.FirstOrDefault(c => c.Id == 1);

            Assert.NotNull(vehicle);
            Assert.NotNull(customer);

            Assert.Equal("Opel", vehicle.Brand);
            Assert.Equal("Corsa", vehicle.Model);
            Assert.Equal("9999ABC", vehicle.Plate);
            Assert.Equal(DateTime.Now.Date, vehicle.ManufacturingDate.Date);

            Assert.Equal("jccandelabordera@gmail.com", customer.Email);
        }
    }
}
