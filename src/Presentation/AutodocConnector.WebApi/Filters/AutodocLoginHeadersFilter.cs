using AutodocConnector.WebApi.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutodocConnector.WebApi.Filters;

/// <summary>
/// Swagger operation filter which adds the autodoc header parameters to parts of autodoc rest api (in AutodocController)
/// </summary>
public class AutodocLoginHeadersFilter : IOperationFilter
{
    /// <inheritdoc/>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo.DeclaringType?.Name == nameof(AutodocController))
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "string" },
                Name = "userName",
                Required = true,
                Description = "Autodoc user name for authentication"
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "string" },
                Name = "password",
                Required = true,
                Description = "Autodoc password for authentication"
            });
        }
    }
}
