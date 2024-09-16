namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin;

public class AutodocLoginCommandHandler : IRequestHandler<AutodocLoginRequest, AutodocLoginResponse>
{
    private readonly AutodocLoginValidator validator;
    private readonly IUserRepository userRepository;

    public AutodocLoginCommandHandler(AutodocLoginValidator validator,IUserRepository userRepository)
    {
        this.validator = validator;
        this.userRepository = userRepository;
    }

    public async Task<AutodocLoginResponse> Handle(AutodocLoginRequest request, CancellationToken cancellationToken)
    {
        validator.Validate(request);
        var user = await userRepository.AutodocLoginAsync(request.UserName,request.Password);

        return new AutodocLoginResponse
        {
            UserId = user.Id,
            CountryCode = user.CountryCode,
        };
    }
}
