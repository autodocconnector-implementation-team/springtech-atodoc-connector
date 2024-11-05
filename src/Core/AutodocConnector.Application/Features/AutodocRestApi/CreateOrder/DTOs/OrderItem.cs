namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder.DTOs;

public record OrderItem
{
    /// <summary>
    /// The unique ID of the product.
    /// </summary>
    public string ProductId { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
}
