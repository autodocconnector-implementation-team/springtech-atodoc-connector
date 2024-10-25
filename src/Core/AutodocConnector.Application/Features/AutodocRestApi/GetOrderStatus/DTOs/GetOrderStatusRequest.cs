namespace AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus.DTOs;

/// <summary>
/// Autodoc get order status request DTO
/// </summary>
public record GetOrderStatusRequest : IRequest<GetOrderStatusResponse>
{
    public string OrderId { get; set; } = string.Empty;
}
