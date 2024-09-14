namespace AutodocConnector.Application.Interfaces.ForPersistence;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
}
