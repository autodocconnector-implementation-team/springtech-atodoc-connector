using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of UserToken entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class UserTokenConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : UserToken
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("user-tokens", DbContext.DB_SCHEMA);
            builder.HasNoKey();

            builder.Property(e => e.LoginProvider)
                .HasColumnName(nameof(UserLogin.LoginProvider).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();

            builder.Property(e => e.Value)
                .HasColumnName(nameof(UserLogin.ProviderDisplayName).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.Name)
                .HasColumnName(nameof(UserLogin.ProviderKey).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName(nameof(UserLogin.UserId).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .IsRequired();
        }
    }
}