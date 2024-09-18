namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin;


public class AutodocLoginCommandHandler : IRequestHandler<AutodocLoginRequest, AutodocLoginResponse>
{
    private readonly AutodocLoginValidator validator;
    private readonly IUserRepository repository;

    public AutodocLoginCommandHandler(AutodocLoginValidator validator,IUserRepository repository)
    {
        this.validator = validator;
        this.repository = repository;
    }

    public async Task<AutodocLoginResponse> Handle(AutodocLoginRequest request, CancellationToken cancellationToken)
    {
        validator.Validate(request);
        var user = await repository.AutodocLoginAsync(request.UserName,request.Password);

        return new AutodocLoginResponse
        {
            UserId = user.Id,
            CountryCode = user.CountryCode,
        };
    }
}
