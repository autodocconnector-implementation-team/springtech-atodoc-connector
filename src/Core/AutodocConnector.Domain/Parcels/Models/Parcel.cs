using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.Parcels.Models
{
    /// <summary>
    /// Parcel entity
    /// </summary>
    public class Parcel : DomainEntity, IAggregateRoot
    {

        public string? DateEstimatedDelivery { get; set; }
        public string? DateShipped { get; set; }
        public int? ParcelNumber { get; set; }
        public string? Service { get; set; }
        public string? Tracking { get; set; }


    }
}
