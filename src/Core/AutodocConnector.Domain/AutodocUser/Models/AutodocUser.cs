using AutodocConnector.Domain.Abstracts;

namespace AutodocConnector.Domain.Users.Models;

/// <summary>
/// Autodoc user for autodoc authentication method
/// </summary>
public class AutodocUser : User, IAggregateRoot
{
    /// <summary>
    /// Autodoc user assigned country
    /// </summary>
    public Country.Country Country { get; set; } = new();
}
