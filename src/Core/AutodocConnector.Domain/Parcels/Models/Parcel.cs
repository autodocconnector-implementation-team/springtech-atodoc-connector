using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutodocConnector.Domain.Abstracts;

namespace AutodocConnector.Domain.Parcels.Models
{
    /// <summary>
    /// Parcel entity
    /// </summary>
    public class Parcel : DomainEntity, IAggregateRoot
    {
        /// <summary>
        /// Date of the estimated delivery - DD.MM.YYYY
        /// </summary>
        public string? DateEstimatedDelivery { get; set; }
        /// <summary>
        /// Date of shipping - DD.MM.YYYY
        /// </summary>
        public string? DateShipped { get; set; }
        /// <summary>
        /// Parcel number
        /// </summary>
        public int? ParcelNumber { get; set; }
        /// <summary>
        /// Name of the shipping service
        /// </summary>
        public string? Service { get; set; }
        /// <summary>
        /// Link to the tracking information
        /// </summary>
        public string? Tracking { get; set; }
    }
}
