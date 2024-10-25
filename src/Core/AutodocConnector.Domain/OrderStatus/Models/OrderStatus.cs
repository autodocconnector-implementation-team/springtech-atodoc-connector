using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.OrderStatus.Models
{
    /// <summary>
    /// OrderStatus domain entity
    /// e.g. 1 = in progress, 2 = order shipped, 3 = order canceled, 4 = returned, 5 = ordered, 6 = delivered to customer
    /// </summary>
    public class OrderStatus : DomainEntity, IAggregateRoot
    {
        /// <summary>
        /// Status Identifier
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Status Name
        /// </summary>
        public string StatusName { get; set; } = string.Empty;
    }
}
