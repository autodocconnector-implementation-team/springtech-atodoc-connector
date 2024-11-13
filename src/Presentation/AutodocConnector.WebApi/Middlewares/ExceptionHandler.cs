using AutodocConnector.Application.Features.AutodocRestApi.DTOs;
using AutodocConnector.Application.Features.AutodocRestApi.GetStock.DTOs;
using AutodocConnector.WebApi.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AutodocConnector.WebApi.Middlewares;

/// <summary>
/// Handle the exceptions in presentaion layer
/// </summary>
public class ExceptionHandler : IExceptionHandler
{
    /// <inheritdoc/>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
        var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is Exception)
        {
            if (httpContext.Items.TryGetValue("__OriginalEndpoint", out object? originalEndPoint))
            {
                if (originalEndPoint is Endpoint && (originalEndPoint as Endpoint)!.DisplayName!.Contains(nameof(AutodocController)))
                {
                    var producesResponseWhenStatus500 = (originalEndPoint as Endpoint)!.Metadata.FirstOrDefault(x => x is ProducesResponseTypeAttribute<GetStockResponse>
                        && (x as ProducesResponseTypeAttribute<GetStockResponse>)!.StatusCode == StatusCodes.Status500InternalServerError);
                    var response = Activator.CreateInstance((producesResponseWhenStatus500 as ProducesResponseTypeAttribute<GetStockResponse>)!.Type);
                    (response as AutodocResponse)!.SetError(exceptionHandlerPathFeature!.Error.Message);
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
        return true;
    }
}
