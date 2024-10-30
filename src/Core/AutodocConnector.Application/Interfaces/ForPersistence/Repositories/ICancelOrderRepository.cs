namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories;

/// <summary>
/// CancelOrder repository declaration for persistence layer
/// </summary>
public interface ICancelOrderRepository
{
    /// <summary>
    /// "Deletes" orders
    /// </summary>
    /// <param name="orderId">Order id</param>
    /// <returns>Bool - indicating success</returns>
    Task<bool> DeleteOrderByOrderIdAsync(string orderId);
}
