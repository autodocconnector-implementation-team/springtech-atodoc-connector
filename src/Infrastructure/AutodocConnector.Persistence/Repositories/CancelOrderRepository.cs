using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;

namespace AutodocConnector.Persistence.Repositories;
/// <summary>
/// Repository implementation for cancel order agreagte root
/// </summary>
internal class CancelOrderRepository : ICancelOrderRepository
{
    /// <inheritdoc/>
    public Task<bool> DeleteOrderByOrderIdAsync(string orderId)
    {
        throw new NotImplementedException();
    }
}
