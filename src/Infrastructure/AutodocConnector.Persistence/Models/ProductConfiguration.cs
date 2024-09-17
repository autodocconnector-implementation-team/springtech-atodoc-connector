using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ColumnTypes = AutodocConnector.Persistence.Context.ColumnTypes;

namespace AutodocConnector.Persistence.Models;

internal class ProductConfiguration : MasterDataEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product).ToLower());

        builder.Property(e => e.Active)
            .HasColumnName(nameof(MasterDataEntity.Active).ToLower())
            .HasColumnType(ColumnTypes.Boolean)
            .IsRequired();
    }
}
