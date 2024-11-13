using AutodocConnector.Domain.Abstracts;

namespace AutodocConnector.Domain.Country;

/// <summary>
/// Represents a Country
/// </summary>
public class Country : DomainEntity, IAggregateRoot
{
    /// <summary>
    /// ISO Country code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of country
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
