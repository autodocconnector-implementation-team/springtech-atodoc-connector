using AutodocConnector.Domain.OrderStatus.Models;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus.DTOs;

/// <summary>
/// Autodoc get order status response DTO
/// </summary>
public record GetOrderStatusResponse : AutodocResponse
{
    /// <summary>
    /// Order id
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order Status
    /// </summary>
    public OrderStatus OrderStatus { get; set; }
}
