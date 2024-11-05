namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin;
public class AutodocLoginValidator : AbstractValidator<AutodocLoginRequest>
{
    public AutodocLoginValidator() 
    {
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.UserName == null || request.Password == null)
            {
                context.AddFailure("The username and the password fields cannot be empty.");
                return false;
            }
            return true;
        });
    }
}
