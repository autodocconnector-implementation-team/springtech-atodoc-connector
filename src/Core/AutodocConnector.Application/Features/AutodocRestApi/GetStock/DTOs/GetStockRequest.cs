using AutodocConnector.Domain.Products.Models;
using System.Runtime.Serialization;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock.DTOs;

/// <summary>
/// Autodoc get stock request DTO
/// </summary>
public record GetStockRequest : IRequest<GetStockResponse>
{
    /// <summary>
    /// Product id - null if not present
    /// </summary>
    public string? ProductId { get; set; }

    /// <summary>
    /// EAN code - null if not present
    /// </summary>
    public string? EAN { get; set; }

    /// <summary>
    /// Country ISO code - null if not present
    /// </summary>
    public string? Country { get; set; }
}
