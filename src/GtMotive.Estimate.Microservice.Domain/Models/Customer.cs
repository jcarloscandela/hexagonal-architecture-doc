using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    /// <summary>
    /// Customer model.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets id of the Customer.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets email of the Customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets rentals of the customer.
        /// </summary>
        public virtual ICollection<Rental> Rentals { get; }
    }
}
