namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs;

/// <summary>
/// Autodoc login request
/// </summary>
public record AutodocLoginRequest : IRequest<AutodocUser>
{
    /// <summary>
    /// User name
    /// </summary>
    public string? UserName { get; set; }
    
    /// <summary>
    /// Password as plain text (!)
    /// </summary>
    public string? Password { get; set; }
}