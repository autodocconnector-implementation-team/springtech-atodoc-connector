namespace AutodocConnector.Persistence.Models;

/// <summary>
/// Base entity - derived from this the all persistence entity which has unique id
/// </summary>
internal abstract class Entity
{
    /// <summary>
    /// Unique identifier which identifies the entity in persistence layer.
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;

    /// <summary>
    /// Entity created timestamp 
    /// </summary>
    public DateTime Created { get; set; } = DateTime.UtcNow;
}
