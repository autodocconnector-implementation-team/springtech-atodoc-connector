namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin;

/// <summary>
/// Validator for autodoc login request
/// </summary>
public class AutodocLoginValidator : AbstractValidator<AutodocLoginRequest>
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <exception cref="Exceptions.ApplicationLayerException"></exception>
    public AutodocLoginValidator() 
    {
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.UserName == null || request.Password == null)
            {
                throw new Exceptions.ApplicationLayerException("The username and the password fields cannot be empty.");
            }
            return true;
        });
    }
}
