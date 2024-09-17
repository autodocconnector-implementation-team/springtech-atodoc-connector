using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutodocConnector.Persistence.Context;

internal class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<DbContext>
{
    public DbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseNpgsql(x => x.MigrationsHistoryTable("__EFMigrationsHistory", DbContext.DB_SCHEMA));
        optionsBuilder.EnableSensitiveDataLogging();

        return new DbContext(optionsBuilder.Options);
    }
} 