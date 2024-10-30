namespace AutodocConnector.Application.Interfaces.ForPersistence;

/// <summary>
/// Unit of Work intarface
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Persist all changes from (tracked) Context.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
}
