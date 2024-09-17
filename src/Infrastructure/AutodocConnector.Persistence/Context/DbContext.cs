using AutodocConnector.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Persistence.Context
{
    /// <summary>
    /// The db context of the identity database. Data seeding is defined here.
    /// </summary>
    internal class DbContext : IdentityDbContext
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
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Addd the Postgres Extension for UUID generation
            //builder.HasPostgresExtension(UUID_GENERATOR);
            // define configurations
            builder.ApplyConfiguration(new ProductConfiguration());

            //Data seeding, so the identity db has a role already.

            var userRoleId = "714d2baf-6432-4510-b52a-08c1017049e3";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = userRoleId.ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
