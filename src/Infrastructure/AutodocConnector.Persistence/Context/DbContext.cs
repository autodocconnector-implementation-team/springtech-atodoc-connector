using AutodocConnector.Persistence.Extensions;
using AutodocConnector.Persistence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutodocConnector.Persistence.Context
{
    /// <summary>
    /// The db context of the persistance layer of autodoc connector.
    /// </summary>
    internal class DbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        /// <summary>
        /// Databse context on this Database schema works
        /// </summary>
        public const string DB_SCHEMA = "autodoc-connector";
        /// <summary>
        /// UUID (~GUID) generator database extension
        /// </summary>
        public const string UUID_GENERATOR = "uuid-ossp";
        /// <summary>
        /// Used UUID generator algorithm
        /// </summary>
        public const string UUID_ALGORITHM = "uuid_generate_v4()";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Otions of create</param>
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products => Set<Product>();

        /// <summary>
        /// Countries
        /// </summary>
        public DbSet<Country> Countries => Set<Country>();

        public DbSet<AutodocUser> AutodocUsers => Set<AutodocUser>();

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Addd the Postgres Extension for UUID generation
            builder.HasPostgresExtension(UUID_GENERATOR);
            
            // ORM configurations
            builder.ApplyConfiguration(new EntityConfigurations.ProductConfiguration());
            builder.ApplyConfiguration(new EntityConfigurations.CountryConfiguration() { SetName = nameof(Countries).ToKebabCase() });
            builder.ApplyConfiguration(new EntityConfigurations.RoleConfiguration<Role>());
            builder.ApplyConfiguration(new EntityConfigurations.RoleClaimConfiguration<RoleClaim>());
            builder.ApplyConfiguration(new EntityConfigurations.UserRoleConfiguration<UserRole>());
            builder.ApplyConfiguration(new EntityConfigurations.UserConfiguration<User>());
            builder.ApplyConfiguration(new EntityConfigurations.UserClaimConfiguration<UserClaim>());
            builder.ApplyConfiguration(new EntityConfigurations.UserLoginConfiguration<UserLogin>());
            builder.ApplyConfiguration(new EntityConfigurations.UserTokenConfiguration<UserToken>());
            builder.ApplyConfiguration(new EntityConfigurations.AutodocUserConfiguration<AutodocUser>());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //            => optionsBuilder.LogTo(LogQuerysToFile);

        //private void LogQuerysToFile(string logLine)
        //{
        //    if (string.IsNullOrEmpty(logLine) || !logLine.Contains("Executed DbCommand"))
        //    {
        //        return;
        //    }
        //    FileStream fileStream = new FileStream($@"D:\temp\{this.ContextId.InstanceId}_{this.ContextId.Lease}.ef.log.txt", FileMode.Append);
        //    using (StreamWriter w = new StreamWriter(fileStream))
        //    {
        //        w.WriteLine(logLine);
        //    }
        //}
    }
}
