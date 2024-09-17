namespace AutodocConnector.Persistence.Models;

/// <summary>
/// Base entity - derived from this the all persistence entity
/// </summary>
internal abstract class Entity
{
    /// <summary>
    /// Unique identifier which represents this entity in persistence layer
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Entity created timestamp 
    /// </summary>
    public DateTime Created { get; set; } = DateTime.UtcNow;
}
