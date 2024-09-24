using Microsoft.EntityFrameworkCore;

namespace AutodocConnector.Persistence.Models;

/// <summary>
/// Country entity
/// </summary>
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(Name), IsUnique = true)]
internal class Country : MasterDataEntity
{
    /// <summary>
    /// ISO Country code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Name of country
    /// </summary>
    public string? Name { get; set; }
}
