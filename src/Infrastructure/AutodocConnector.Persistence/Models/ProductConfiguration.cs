using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of Country entity
    /// </summary>
    internal class ProductConfiguration : MasterDataEntityConfiguration<Product>
    {
        /// <inheritdoc/>
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ArticleNumber)
                .HasColumnName(nameof(Product.ArticleNumber).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);
 
            builder.Property(e => e.Name)
                .HasColumnName(nameof(Product.Name).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.Description)
                .HasColumnName(nameof(Product.Description).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.Ean)
                .HasColumnName(nameof(Product.Ean).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.Stocks)
                .HasColumnName(nameof(Product.Stocks).ToKebabCase())
                .HasColumnType(ColumnTypes.Integer);
        }
    }
}
