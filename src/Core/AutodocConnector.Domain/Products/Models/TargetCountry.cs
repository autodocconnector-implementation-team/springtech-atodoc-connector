using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.Products.Models
{
    /// <summary>
    /// Target country of sales
    /// </summary>
    public class TargetCountry : DomainEntity
    {   
        /// <summary>
        /// ISO country code
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// Country name
        /// </summary>
        public string CountryName { get; set; } = string.Empty;
    }
}
