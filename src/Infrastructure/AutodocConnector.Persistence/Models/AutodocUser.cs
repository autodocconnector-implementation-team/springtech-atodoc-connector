namespace AutodocConnector.Persistence.Models;

/// <summary>
/// Autodoc technikal user for autodoc authentication methode only
/// </summary>
internal class AutodocUser : User
{
    /// <summary>
    /// This country is assigned to this autodoc technical user
    /// </summary>
    public Guid? AssignedCountryId { get; set; }
    
    /// <summary>
    /// Navigation property to assigned country entity
    /// </summary>
    public Country? AssignedCountry { get; set; }
}
