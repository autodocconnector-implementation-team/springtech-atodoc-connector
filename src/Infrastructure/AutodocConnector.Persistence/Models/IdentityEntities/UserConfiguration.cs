using AutodocConnector.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutodocConnector.Persistence.Models;

internal abstract partial class EntityConfigurations
{
    /// <summary>
    /// ORM configuration of User entity type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class UserConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : User
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable("users", DbContext.DB_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName(nameof(User.Id).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .HasDefaultValueSql(DbContext.UUID_ALGORITHM)
                .IsRequired();

            builder.Property(e => e.AccessFailedCount)
                .HasColumnName(nameof(User.AccessFailedCount).ToKebabCase())
                .HasColumnType(ColumnTypes.Integer)
                .IsRequired();

            builder.Property(e => e.ConcurrencyStamp)
                .HasColumnName(nameof(User.ConcurrencyStamp).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .HasConversion(typeof(Guid));

            builder.Property(e => e.Email)
                .HasColumnName(nameof(User.Email).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.EmailConfirmed)
                .HasColumnName(nameof(User.EmailConfirmed).ToKebabCase())
                .HasColumnType(ColumnTypes.Boolean)
                .IsRequired();

            builder.Property(e => e.LockoutEnabled)
                .HasColumnName(nameof(User.LockoutEnabled).ToKebabCase())
                .HasColumnType(ColumnTypes.Boolean)
                .IsRequired();

            builder.Property(e => e.LockoutEnd)
                .HasColumnName(nameof(User.LockoutEnd).ToKebabCase())
                .HasColumnType(ColumnTypes.DateTimeOffset);

            builder.Property(e => e.NormalizedEmail)
                .HasColumnName(nameof(User.NormalizedEmail).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.NormalizedUserName)
                .HasColumnName(nameof(User.NormalizedUserName).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.PasswordHash)
                .HasColumnName(nameof(User.PasswordHash).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.PhoneNumber)
                .HasColumnName(nameof(User.PhoneNumber).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);

            builder.Property(e => e.PhoneNumberConfirmed)
                .HasColumnName(nameof(User.PhoneNumberConfirmed).ToKebabCase())
                .HasColumnType(ColumnTypes.Boolean)
                .IsRequired();

            builder.Property(e => e.SecurityStamp)
                .HasColumnName(nameof(User.SecurityStamp).ToKebabCase())
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .HasConversion(typeof(Guid));

            builder.Property(e => e.TwoFactorEnabled)
                .HasColumnName(nameof(User.TwoFactorEnabled).ToKebabCase())
                .HasColumnType(ColumnTypes.Boolean)
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasColumnName(nameof(User.UserName).ToKebabCase())
                .HasColumnType(ColumnTypes.Text);
        }
    }
}