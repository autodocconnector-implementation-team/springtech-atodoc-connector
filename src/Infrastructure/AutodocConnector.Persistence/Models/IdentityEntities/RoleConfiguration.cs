using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of Role entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class RoleConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Role
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("roles", DbContext.DB_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName(nameof(Role.Id).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .HasDefaultValueSql(DbContext.UUID_ALGORITHM)
                .IsRequired();

            builder.Property(e => e.ConcurrencyStamp)
                .HasColumnName(nameof(Role.ConcurrencyStamp).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.Name)
                .HasColumnName(nameof(Role.Name).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.NormalizedName)
                .HasColumnName(nameof(Role.NormalizedName).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);
        }
    }
}
