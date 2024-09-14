namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock.DTOs;

/// <summary>
/// Autodoc get stock response DTO
/// </summary>
public record GetStockResponse : AutodocResponse
{
    public string? ProductId { get; set; }

    public int Amount { get; set; } = 0;

    public decimal Price { get; set; } = 0;
}
