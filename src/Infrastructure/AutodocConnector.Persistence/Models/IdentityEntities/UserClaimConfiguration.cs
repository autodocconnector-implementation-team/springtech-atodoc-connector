using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of UserClaim entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class UserClaimConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : UserClaim
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("user-claims", DbContext.DB_SCHEMA);
            builder.HasKey( e => e.Id );

            builder.Property(e => e.ClaimType)
                .HasColumnName(nameof(UserClaim.ClaimType).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.ClaimValue)
                .HasColumnName(nameof(UserClaim.ClaimValue).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.UserId)
                .HasColumnName(nameof(UserClaim.UserId).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier);
        }
    }
}