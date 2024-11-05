namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder.DTOs;

public record CreateOrderResponse : AutodocResponse
{
    /// <summary>
    /// "Supplier" OrderId
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// The items associated with the order
    /// </summary>
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
}
