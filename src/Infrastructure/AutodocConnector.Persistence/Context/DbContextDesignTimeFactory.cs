using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutodocConnector.Persistence.Context;

/// <summary>
/// Designtime context factory for entity framework built in tools. <see cref="https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli"/>
/// </summary>
internal class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<DbContext>
{
    /// <inheritdoc/>
    public DbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseNpgsql(x => x.MigrationsHistoryTable("__EFMigrationsHistory", DbContext.DB_SCHEMA));
        optionsBuilder.EnableSensitiveDataLogging();

        return new DbContext(optionsBuilder.Options);
    }
}