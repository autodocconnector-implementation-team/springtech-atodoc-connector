using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using AutodocConnector.Domain.Parcels.Models;

namespace AutodocConnector.Persistence.Repositories;

/// <summary>
/// DI implementation of IGetTrackingNumbersRepository service dependency
/// </summary>
internal class GetTrackingNumbersRepository : IGetTrackingNumbersRepository
{
    /// <inheritdoc/>
    public Task<List<Parcel>> GetParcelsByOrderIdAsync(string orderId)
    {
        throw new NotImplementedException();
    }
}
