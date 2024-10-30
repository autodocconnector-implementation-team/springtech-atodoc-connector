using AutodocConnector.Application.Features.AutodocRestApi.GetStock.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutodocConnector.WebApi.Controllers;

/// <summary>
/// Controller for autodoc (autodoc http api)
/// </summary>
[ApiController]
[Route("[controller]")]
public class AutodocController: ControllerBase
{
    private readonly IMediator _mediator;

    public AutodocController(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Gets stock informations an product
    /// </summary>
    /// <param name="productId">Unique product identifier (item number)</param>
    /// <param name="ean">EAN code of product</param>
    /// <param name="countryCode">ISO 3166-1 alpha-2 country code</param>
    /// <returns>Stock and price information of product</returns>
    [HttpGet(nameof(GetStock))]
    [ProducesResponseType<GetStockResponse>(StatusCodes.Status200OK)]
    public async Task<GetStockResponse> GetStock([FromQuery]string? productId, [FromQuery]string? ean, [FromQuery]string? countryCode)
    {
        return await _mediator.Send(new GetStockRequest { ProductId = productId, EAN = ean, Country = countryCode });
    }

}
