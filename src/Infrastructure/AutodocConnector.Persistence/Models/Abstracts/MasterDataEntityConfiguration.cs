using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

/// <summary>
/// ORM configuration of MAsterDataEntity type
/// </summary>
/// <typeparam name="TEntity"></typeparam>
internal abstract class MasterDataEntityConfiguration<TEntity> : EntityConfiguration<TEntity>, IEntityTypeConfiguration<TEntity> where TEntity : MasterDataEntity
{
    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Active)
            .HasColumnName(nameof(MasterDataEntity.Active).ToKebabCase())
            .HasColumnType(ColumnTypes.Boolean)
            .IsRequired();
    }
}
