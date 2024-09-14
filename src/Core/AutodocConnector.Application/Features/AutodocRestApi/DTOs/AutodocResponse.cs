namespace AutodocConnector.Application.Features.AutodocRestApi.DTOs;

/// <summary>
/// Autodoc api base response abstarct class - parent of all Response object
/// </summary>
public abstract record AutodocResponse
{
    /// <summary>
    /// Indicates Success or error response
    ///  1 if no error
    ///  0 if error occured
    /// </summary>
    public int Succes { get; set; } = 1;

    /// <summary>
    /// Error mesaage if error occured otherwise empty
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;

    public void SetError(string message) 
    { 
        ErrorMessage = message;
        Succes = 0;
    }
}
