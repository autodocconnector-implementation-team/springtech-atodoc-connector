namespace AutodocConnector.Persistence.Models;

/// <summary>
/// Master data base entity - derived from this the all master data entity
/// </summary>
internal abstract class MasterDataEntity : Entity
{
    /// <summary>
    /// Indicates this entity active or not (deleted)
    /// </summary>
    public bool Active { get; set; } = true;
}
