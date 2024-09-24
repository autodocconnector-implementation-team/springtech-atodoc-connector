using Microsoft.AspNetCore.Identity;
namespace AutodocConnector.Persistence.Models;

/// <summary>
/// General user entity. This is an abstract base class only, expand to derived class if need. 
/// </summary>
abstract internal class User : IdentityUser<Guid>
{
}
