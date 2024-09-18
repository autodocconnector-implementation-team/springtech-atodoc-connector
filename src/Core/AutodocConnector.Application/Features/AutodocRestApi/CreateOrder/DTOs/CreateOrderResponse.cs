namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder.DTOs;

public record CreateOrderResponse : AutodocResponse
{
    public string OrderId { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
}
