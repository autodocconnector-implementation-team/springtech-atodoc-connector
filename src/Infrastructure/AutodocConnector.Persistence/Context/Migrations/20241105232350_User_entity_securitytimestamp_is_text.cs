using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutodocConnector.Persistence.Context.Migrations
{
    /// <inheritdoc />
    public partial class User_entity_securitytimestamp_is_text : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "security-stamp",
                schema: "autodoc-connector",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "security-stamp",
                schema: "autodoc-connector",
                table: "users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
