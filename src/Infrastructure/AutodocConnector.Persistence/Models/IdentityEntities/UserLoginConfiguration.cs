using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of UserLogin entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class UserLoginConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : UserLogin
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("user-logins", DbContext.DB_SCHEMA);
            builder.HasNoKey();

            builder.Property(e => e.LoginProvider)
                .HasColumnName(nameof(UserLogin.LoginProvider).ToKebabCase())
                .HasColumnType(ColumnTypes.Text)
                .IsRequired();

            builder.Property(e => e.ProviderDisplayName)
                .HasColumnName(nameof(UserLogin.ProviderDisplayName).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.ProviderKey)
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