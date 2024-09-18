namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder.DTOs;

public record OrderItem
{
    public string ProductId { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
}
