namespace AutodocConnector.Common.Exceptions;

/// <summary>
/// This exception throwings if authentication methode is failed (http excpetionhandler midleware provides 401 status code)
/// </summary>
public class AuthentictionException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Error message</param>
    public AuthentictionException(string? message) : base(message) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="innerException">Inner exception</param>
    public AuthentictionException(string? message, Exception? innerException) : base(message, innerException) { }
}
