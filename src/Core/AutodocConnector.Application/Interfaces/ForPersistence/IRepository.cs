namespace AutodocConnector.Application.Interfaces.ForPersistence;

/// <summary>
/// Define UOW abstaraction in repository. All repository interface must descend from this.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : IAggregateRoot
{
    /// <summary>
    /// This property gets Unit of Work instance
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}
