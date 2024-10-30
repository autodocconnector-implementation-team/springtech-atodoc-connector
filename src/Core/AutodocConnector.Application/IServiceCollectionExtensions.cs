using AutodocConnector.Application.Features.AutodocRestApi.GetStock;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutodocConnector.Application;

public static class IServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediator();
        services.AddValidators();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //cfg.RegisterServicesFromAssemblyContaining<ApplicationException>();
        });
    }

    private static void AddValidators(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssemblyContaining<GetStockRequestValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
