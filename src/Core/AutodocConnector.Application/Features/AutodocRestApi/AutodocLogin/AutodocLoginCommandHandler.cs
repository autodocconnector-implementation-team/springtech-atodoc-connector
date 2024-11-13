namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin;

/// <summary>
/// Handle AutodocLogin request
/// </summary>
public class AutodocLoginCommandHandler : IRequestHandler<AutodocLoginRequest, AutodocUser>
{
    private readonly AutodocLoginValidator validator;
    private readonly IAutodocUserRepository repository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="validator">Validator service</param>
    /// <param name="repository">Repsitory service</param>
    public AutodocLoginCommandHandler(AutodocLoginValidator validator,IAutodocUserRepository repository)
    {
        this.validator = validator;
        this.repository = repository;
    }

    /// <summary>
    /// Request handler
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Autodoc user</returns>
    public async Task<AutodocUser> Handle(AutodocLoginRequest request, CancellationToken cancellationToken)
    {
        validator.Validate(request);
        return await repository.AutodocLogin(request.UserName!,request.Password!);
    }
}
