namespace AutodocConnector.Application.Features.AutodocRestApi.CancelOrder.DTOs;

/// <summary>
/// Autodoc cancel order request DTO
/// </summary>
public record CancelOrderRequest : IRequest<CancelOrderResponse>
{
    /// <summary>
    /// Supplier order id - not null
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Comment - null if not present
    /// </summary>
    public string? Comment { get; set; }
}
