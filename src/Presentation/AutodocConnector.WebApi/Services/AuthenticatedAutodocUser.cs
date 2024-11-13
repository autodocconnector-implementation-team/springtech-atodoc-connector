using AutodocConnector.Application.Interfaces.ForPresentation;
using AutodocConnector.Domain.Users.Models;
using Newtonsoft.Json;

namespace AutodocConnector.WebApi.Services;
/// <summary>
/// Authenticated autodoc user provider
/// </summary>
internal class AuthenticatedAutodocUser : IAuthenticatedAutodocUser
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpContext">Http context</param>
    /// <exception cref="Common.Exceptions.AuthentictionException"></exception>
    public AuthenticatedAutodocUser(IHttpContextAccessor? httpContext)
    {
        if (httpContext?.HttpContext?.User?.Identity == null || !(httpContext!.HttpContext!.User!.Identity!.IsAuthenticated) 
            || httpContext.HttpContext.User.Claims?.FirstOrDefault(x => x.Type == ClaimType.AutodocUserData.ToString())?.Value == null)
        {
            throw new Common.Exceptions.AuthentictionException("User not setted in http context!");
        }
        User = JsonConvert.DeserializeObject<AutodocUser>(httpContext!.HttpContext!.User!.Claims!.First(x => x.Type == ClaimType.AutodocUserData.ToString())!.Value!)!;
    }

    /// <inheritdoc/>
    public AutodocUser User { get; }
}
