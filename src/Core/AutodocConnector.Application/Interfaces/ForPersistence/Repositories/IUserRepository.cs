namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
public interface IUserRepository
{
    /// <summary>
    /// This is used to check whether the user exists in the Identity Database or not.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<User> AutodocLoginAsync(string username, string password);
}
