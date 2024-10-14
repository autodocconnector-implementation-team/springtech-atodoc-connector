using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutodocConnector.Domain.Products.Models;
using System.Runtime.Serialization;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetTrackingNumbers.DTOs;

/// <summary>
/// Autodoc get tracking numbers request DTO
/// </summary>
public record GetTrackingNumbersRequest : IRequest<GetTrackingNumbersResponse>
{
    /// <summary>
    /// Order id - null if not present
    /// </summary>
    public string? OrderID { get; set; }
}

