
using AutodocConnector.Application.Features.AutodocRestApi.AutodocLogin.DTOs;
using AutodocConnector.Domain.Users.Models;
using AutodocConnector.WebApi.Authentication;
using AutodocConnector.WebApi.Controllers;
using MediatR;
using System.Net;
using System.Security.Claims;

namespace AutodocConnector.WebApi.Middlewares;

/// <summary>
/// Authentication middleware for autodc rest api
/// </summary>
public class AutodocAuthenticationMiddleware : IMiddleware
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator">Mediator service</param>
    public AutodocAuthenticationMiddleware(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <inheritdoc/>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.GetEndpoint()?.DisplayName?.Contains(nameof(AutodocController)) ?? false)
        {
            try
            {
                var autodocUser = await _mediator.Send(new AutodocLoginRequest
                {
                    UserName = context.Request?.Headers[nameof(AutodocLoginRequest.UserName)],
                    Password = context.Request?.Headers[nameof(AutodocLoginRequest.Password)]
                });
                var autodocUserClaim = new Claim<ClaimType, AutodocUser>(ClaimType.AutodocUserData, autodocUser);
                var identity = new ClaimsIdentity(new[]
                {
                        new Claim(autodocUserClaim.Type, autodocUserClaim.Value),
                    }, AuthenticationType.Autodoc.ToString());
                context.User = new ClaimsPrincipal(identity);
            }
            catch (Exception ex)
            {
                // TODO: Exception into body?
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
        }
        await next.Invoke(context);
    }
}
