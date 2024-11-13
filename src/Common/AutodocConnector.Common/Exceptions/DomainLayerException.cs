namespace AutodocConnector.Common.Exceptions;

/// <summary>
/// General Exception in domain layer. (Http exceptionhandler midleware provide 500 http status, except Autodoc rest api, which provides 200 status.)
/// </summary>
public class DomainLayerException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Error message</param>
    public DomainLayerException(string? message) : base(message) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="innerException">Inner exception object</param>
    public DomainLayerException(string? message, Exception? innerException) : base(message, innerException) { }
}
