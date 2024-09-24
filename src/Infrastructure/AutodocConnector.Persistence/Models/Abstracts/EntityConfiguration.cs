using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models
{
    /// <summary>
    /// ORM configuration of Entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Define name of set (table) here, use this if the plural form is not evident. Otherwise not need to set.
        /// </summary>
        public string? SetName { get; set; }

        /// <inheritdoc/>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(string.IsNullOrWhiteSpace(SetName) ? $"{typeof(TEntity).Name.ToKebabCase()}s" : SetName, DbContext.DB_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName(nameof(Entity.Id).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .HasDefaultValueSql(DbContext.UUID_ALGORITHM)
                .IsRequired();

            builder.Property(e => e.Created)
                .HasColumnName(nameof(Entity.Created).ToKebabCase())
                .HasColumnType(ColumnTypes.UTCTimestamp)
                .IsRequired();
        }
    }
}
