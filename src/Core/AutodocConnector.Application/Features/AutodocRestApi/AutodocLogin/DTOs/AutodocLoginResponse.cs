namespace AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs;

public record AutodocLoginResponse
{
    public string UserId { get; set; }
    public string CountryCode { get; set; }
}
