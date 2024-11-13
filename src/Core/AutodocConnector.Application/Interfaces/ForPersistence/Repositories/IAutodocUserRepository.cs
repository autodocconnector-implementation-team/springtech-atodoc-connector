namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories;

/// <summary>
/// User repository defination
/// </summary>
public interface IAutodocUserRepository
{
    /// <summary>
    /// Login
    /// </summary>
    /// <param name="userName">Autodoc user defined user name</param>
    /// <param name="password">Password of autodocuser</param>
    /// <returns></returns>
    Task<AutodocUser> AutodocLogin(string userName, string password);
}
