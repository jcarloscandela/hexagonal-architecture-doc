using System;
using FluentValidation;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Validators
{
    /// <summary>
    /// Vehicle Validator.
    /// </summary>
    public class VehicleValidator : AbstractValidator<VehicleDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleValidator"/> class.
        /// </summary>
        public VehicleValidator()
        {
            RuleFor(vehicle => vehicle.Brand)
                .NotEmpty()
                .WithMessage("Manufacturing date is required.");

            RuleFor(vehicle => vehicle.Model)
                .NotEmpty()
                .WithMessage("Manufacturing date is required.");

            RuleFor(vehicle => vehicle.Plate)
                .NotEmpty()
                .WithMessage("Manufacturing date is required.");

            RuleFor(vehicle => vehicle.ManufacturingDate)
                .NotEmpty()
                .WithMessage("Manufacturing date is required.")
                .Must(BeWithinFiveYears)
                .WithMessage("Manufacturing date must be within the last 5 years.");
        }

        private bool BeWithinFiveYears(DateTime manufacturingDate)
        {
            // Calculate the difference between the manufacturing date and today's date.
            var difference = DateTime.Today.Year - manufacturingDate.Year;

            // If the difference is more than 5, it means the manufacturing date is over 5 years ago.
            return difference <= 5;
        }
    }
}
