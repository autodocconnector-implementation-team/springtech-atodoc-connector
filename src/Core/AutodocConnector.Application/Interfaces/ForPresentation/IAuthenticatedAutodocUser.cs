namespace AutodocConnector.Application.Interfaces.ForPresentation;
/// <summary>
/// Provide current authenticated user
/// </summary>
public interface IAuthenticatedAutodocUser
{
    /// <summary>
    /// Authenticated autodoc requester user
    /// </summary>
    public AutodocUser User { get; }
}
