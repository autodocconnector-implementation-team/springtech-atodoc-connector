using AutodocConnector.Domain.OrderStatus.Models;

namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories;

/// <summary>
/// GetOrderStatus repository declarition for persistence layer
/// </summary>
public interface IGetOrderStatusRepository
{
    /// <summary>
    /// Get order status by order id
    /// </summary>
    /// <param name="orderId">order Id</param>
    /// <returns>OrderStatus entity</returns>
    Task<OrderStatus> GetOrderStatusByOrderId(string orderId);
}
