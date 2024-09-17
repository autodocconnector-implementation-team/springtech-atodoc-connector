using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ColumnTypes = AutodocConnector.Persistence.Context.ColumnTypes;

namespace AutodocConnector.Persistence.Models;

internal abstract class MasterDataEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : MasterDataEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name.ToKebabCase());
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Active)
            .HasColumnName(nameof(MasterDataEntity.Active).ToLower())
            .HasColumnType(ColumnTypes.Boolean)
            .IsRequired();
    }
}
