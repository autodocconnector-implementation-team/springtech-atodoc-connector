namespace AutodocConnector.Application.Interfaces.ForPersistence;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
