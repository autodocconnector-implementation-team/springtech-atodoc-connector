using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutodocConnector.Domain.Products.Models;
using System.Runtime.Serialization;
using AutodocConnector.Domain.Parcels.Models;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetTrackingNumbers.DTOs;

/// <summary>
/// Autodoc get tracking numbers response DTO
/// </summary>
public record GetTrackingNumbersResponse : AutodocResponse
{
    public string? OrderID { get; set; }
    public List<Parcel> Parcels { get; set; } = new List<Parcel>();
}

