using AutodocConnector.Persistence.Context;
using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of Country entity
    /// </summary>
    internal class CountryConfiguration : MasterDataEntityConfiguration<Country>
    {
        /// <inheritdoc/>
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code)
                .HasColumnName(nameof(Country.Code).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName(nameof(Country.Name).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();
        }
    }
}
