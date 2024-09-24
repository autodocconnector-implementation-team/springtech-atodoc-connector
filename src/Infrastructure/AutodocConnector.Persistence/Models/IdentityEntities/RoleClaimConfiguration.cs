using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of RoleClaim entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class RoleClaimConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : RoleClaim
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("role-claims", DbContext.DB_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName(nameof(RoleClaim.Id).ToKebabCase())
                .HasColumnType(ColumnTypes.Integer)
                .IsRequired();

            builder.Property(e => e.ClaimType)
                .HasColumnName(nameof(RoleClaim.ClaimType).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();

            builder.Property(e => e.ClaimValue)
                .HasColumnName(nameof(RoleClaim.ClaimValue).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();

            builder.Property(e => e.RoleId)
                .HasColumnName(nameof(RoleClaim.RoleId).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .IsRequired();
        }
    }
}
