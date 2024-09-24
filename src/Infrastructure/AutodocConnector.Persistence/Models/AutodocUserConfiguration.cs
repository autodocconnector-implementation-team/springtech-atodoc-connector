using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

/// <summary>
/// A partial class that collects the database binding configuration of all defined entities to facilitate their reference.
/// </summary>
internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of Country entity
    /// </summary>
    internal class AutodocUserConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AutodocUser
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.AssignedCountryId)
                .HasColumnName(nameof(AutodocUser.AssignedCountryId).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .IsRequired();
        }
    }
}
