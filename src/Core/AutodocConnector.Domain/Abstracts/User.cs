namespace AutodocConnector.Domain.Abstracts;

/// <summary>
/// User minimal abstarction (common baseclass of AutodocUser and ApplicationUser)
/// </summary>
public abstract class User : DomainEntity
{
    /// <summary>
    /// User name
    /// </summary>
    public string UserName { get; set; } = string.Empty;
}
