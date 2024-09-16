namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs;

public class AutodocLoginRequest : IRequest<AutodocLoginResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}