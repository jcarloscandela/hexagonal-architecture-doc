using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Validators;
using GtMotive.Estimate.Microservice.Domain.Models;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class Test
    {
        [Fact]
        public void CreateVehicleShouldThrowErrorWhenManufacturingDateIsOver5Years()
        {
            var currentYear = DateTime.Now.Year;
            var sixYearsAgo = new DateTime(currentYear - 6, 1, 1);

            var vehicle = new VehicleDto { Brand = "Opel", Model = "Mokka", ManufacturingDate = sixYearsAgo, Plate = "ABC123" };
            var validator = new VehicleValidator();
            var validationResult = validator.Validate(vehicle);
            Assert.False(validationResult.IsValid);
        }
    }
}
