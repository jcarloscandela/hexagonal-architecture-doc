﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    /// <summary>
    /// Vehicle model.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets id of the vehicle.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets plate of the vehicle.
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets manufacturing date of the vehicle.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// Gets rentals of the vehicle.
        /// </summary>
        public virtual ICollection<Rental> Rentals { get; }
    }
}
