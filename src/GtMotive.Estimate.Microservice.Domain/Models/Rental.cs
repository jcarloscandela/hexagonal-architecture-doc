using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    /// <summary>
    /// Rental model.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Gets or sets id of the rental.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets email of the rental.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets customer id of the rental.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets vehicle id of the rental.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets StartDate of the rental.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate of the rental.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets Customer of the rental.
        /// </summary>
        public virtual Customer Customer { get; }

        /// <summary>
        /// Gets Vehicle of the rental.
        /// </summary>
        public virtual Vehicle Vehicle { get; }
    }
}
