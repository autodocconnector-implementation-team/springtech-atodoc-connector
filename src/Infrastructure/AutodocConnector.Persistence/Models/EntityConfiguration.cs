using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using DbContext = AutodocConnector.Persistence.Context.DbContext;
using ColumnTypes = AutodocConnector.Persistence.Context.ColumnTypes;

namespace AutodocConnector.Persistence.Models
{
    internal abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name.ToKebabCase());
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName(nameof(Entity.Id).ToLower())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                //.HasDefaultValueSql(DbContext.UUID_ALGORITHM)
                .IsRequired();

            builder.Property(e => e.Created)
                .HasColumnName(nameof(Entity.Created).ToLower())
                .HasColumnType(ColumnTypes.UTCTimestamp)
                .IsRequired();
        }
    }
}
