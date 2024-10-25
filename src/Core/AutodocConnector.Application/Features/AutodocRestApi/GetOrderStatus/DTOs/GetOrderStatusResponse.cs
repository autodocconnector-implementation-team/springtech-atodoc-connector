namespace AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus.DTOs;

/// <summary>
/// Autodoc get order status response DTO
/// </summary>
public record GetOrderStatusResponse : AutodocResponse
{
    public string OrderId { get; set; } = string.Empty;

    // TODO either a number (StatusId) or a name (StatusName) - should be decided
    public string OrderStatus { get; set; } = string.Empty;
}
