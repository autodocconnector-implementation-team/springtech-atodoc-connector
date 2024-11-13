using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using AutodocConnector.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace AutodocConnector.Persistence.Extensions.Public;

/// <summary>
/// IServicecollection extensions
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Register all DI services of persistence layer
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    /// <summary>
    /// Register database context
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">Configuration</param>
    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var connectionString = configuration.GetConnectionString("db") ?? "";

        Log.Logger.Information("Startup connectionString: " + connectionString + ", ASPNETCORE_ENVIRONMENT=" + env);

        services.AddDbContext<DbContext>(o =>
        {
            o.UseNpgsql(connectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", DbContext.DB_SCHEMA));
            o.EnableSensitiveDataLogging();
        });
    }

    /// <summary>
    /// Register all repository implementations for all repository interfaces
    /// </summary>
    /// <param name="services"></param>
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddIdentity<Models.User, Models.Role>().AddEntityFrameworkStores<DbContext>();

        services.AddScoped<IGetStockRepository, GetStockRepository>();
        services.AddScoped<IAutodocUserRepository, AutodocUserRepository>();
        services.AddScoped<ICancelOrderRepository, CancelOrderRepository>();
        services.AddScoped<IGetTrackingNumbersRepository, GetTrackingNumbersRepository>();
        services.AddScoped<IGetOrderStatusRepository, GetOrderStatusRepository>();
        services.AddScoped<ICreateOrderRepository,  CreateOrderRepository>();
    }
}
