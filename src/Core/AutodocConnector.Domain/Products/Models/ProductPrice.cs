using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.Products.Models
{
    /// <summary>
    /// Product price domain entity
    /// </summary>
    public class ProductPrice : DomainEntity
    {
        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; } = new();
        
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Valid in this country
        /// </summary>
        public TargetCountry TargetCountry { get; set; } = new();

        /// <summary>
        /// When modify this price
        /// </summary>
        public DateTime? DeactivatedAt { get; set; }

        /// <summary>
        /// Active OVERRIDE the base property!!!
        /// </summary>
        new public bool Active { get => DeactivatedAt == null; }
    }
}
