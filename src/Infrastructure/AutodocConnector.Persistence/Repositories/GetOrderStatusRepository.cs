using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using AutodocConnector.Domain.OrderStatus.Models;

namespace AutodocConnector.Persistence.Repositories;

/// <summary>
/// DI implementation of IGetOrderStatusRepository service dependency
/// </summary>
internal class GetOrderStatusRepository : IGetOrderStatusRepository
{
    /// <inheritdoc/>
    public Task<OrderStatus> GetOrderStatusByOrderIdAsync(string orderId)
    {
        throw new NotImplementedException();
    }
}
