namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs;

public record AutodocLoginRequest : IRequest<AutodocLoginResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}