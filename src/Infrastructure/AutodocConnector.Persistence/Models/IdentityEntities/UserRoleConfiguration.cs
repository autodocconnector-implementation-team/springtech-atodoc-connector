using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of UserRole entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class UserRoleConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : UserRole
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("user-roles", DbContext.DB_SCHEMA);
            builder.HasNoKey();

            builder.Property(e => e.RoleId)
                .HasColumnName(nameof(UserRole.RoleId).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName(nameof(UserRole.UserId).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .IsRequired();
        }
    }
}