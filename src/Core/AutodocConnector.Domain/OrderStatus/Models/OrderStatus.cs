using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Domain.OrderStatus.Models
{
    /// <summary>
    /// OrderStatus enum
    /// </summary>
    public enum OrderStatus 
    {
        InProgress,
        OrderShipped,
        OrderCancelled,
        Returned,
        Ordered,
        DeliveredToCustomer
    }
}
