using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutodocConnector.Persistence.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "autodoc-connector");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "autodoc-connector",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "autodoc-connector",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    articlenumber = table.Column<string>(name: "article-number", type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    ean = table.Column<string>(type: "text", nullable: false),
                    stocks = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role-claims",
                schema: "autodoc-connector",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<Guid>(name: "role-id", type: "uuid", nullable: false),
                    claimtype = table.Column<string>(name: "claim-type", type: "text", nullable: false),
                    claimvalue = table.Column<string>(name: "claim-value", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role-claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "autodoc-connector",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", nullable: true),
                    normalizedname = table.Column<string>(name: "normalized-name", type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(name: "concurrency-stamp", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user-claims",
                schema: "autodoc-connector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<Guid>(name: "user-id", type: "uuid", nullable: false),
                    claimtype = table.Column<string>(name: "claim-type", type: "text", nullable: true),
                    claimvalue = table.Column<string>(name: "claim-value", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user-claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user-logins",
                schema: "autodoc-connector",
                columns: table => new
                {
                    loginprovider = table.Column<string>(name: "login-provider", type: "text", nullable: false),
                    providerkey = table.Column<string>(name: "provider-key", type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(name: "provider-display-name", type: "text", nullable: true),
                    userid = table.Column<Guid>(name: "user-id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "user-roles",
                schema: "autodoc-connector",
                columns: table => new
                {
                    userid = table.Column<Guid>(name: "user-id", type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(name: "role-id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "user-tokens",
                schema: "autodoc-connector",
                columns: table => new
                {
                    userid = table.Column<Guid>(name: "user-id", type: "uuid", nullable: false),
                    loginprovider = table.Column<string>(name: "login-provider", type: "text", nullable: false),
                    providerkey = table.Column<string>(name: "provider-key", type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(name: "provider-display-name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "autodoc-connector",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    assignedcountryid = table.Column<Guid>(name: "assigned-country-id", type: "uuid", nullable: true),
                    username = table.Column<string>(name: "user-name", type: "text", nullable: true),
                    normalizedusername = table.Column<string>(name: "normalized-user-name", type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    normalizedemail = table.Column<string>(name: "normalized-email", type: "text", nullable: true),
                    emailconfirmed = table.Column<bool>(name: "email-confirmed", type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(name: "password-hash", type: "text", nullable: true),
                    securitystamp = table.Column<Guid>(name: "security-stamp", type: "uuid", nullable: true),
                    concurrencystamp = table.Column<Guid>(name: "concurrency-stamp", type: "uuid", nullable: true),
                    phonenumber = table.Column<string>(name: "phone-number", type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(name: "phone-number-confirmed", type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(name: "two-factor-enabled", type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(name: "lockout-end", type: "time with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(name: "lockout-enabled", type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(name: "access-failed-count", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_countries_assigned-country-id",
                        column: x => x.assignedcountryid,
                        principalSchema: "autodoc-connector",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countries_code",
                schema: "autodoc-connector",
                table: "countries",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_name",
                schema: "autodoc-connector",
                table: "countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_article-number",
                schema: "autodoc-connector",
                table: "products",
                column: "article-number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ean",
                schema: "autodoc-connector",
                table: "products",
                column: "ean",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_assigned-country-id",
                schema: "autodoc-connector",
                table: "users",
                column: "assigned-country-id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "role-claims",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "user-claims",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "user-logins",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "user-roles",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "user-tokens",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "users",
                schema: "autodoc-connector");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "autodoc-connector");
        }
    }
}
